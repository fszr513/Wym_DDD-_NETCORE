using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.TagHelpers
{
    /// <summary>
    /// 我的分页Taghelper 可以自定义分页中很多属性
    /// 调用：PageList-wy 即可生成分页代码。
    /// 需要在startup里添加对HttpContextAccessor 注入的引用
    /// services.AddHttpContextAccessor();
    /// </summary>
    [HtmlTargetElement("PageList-wy")]
    public class pagelistTag:TagHelper
    {
        private IHttpContextAccessor _httpContextAccessor;
        private int _totalPages;
        public pagelistTag(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            
        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 页面大小,如不设置此属性默认为 1
        /// </summary>
        public int PageSize { get; set; } = 20;
        /// <summary>
        /// 总共有多少条,如不设置此属性默认为20
        /// </summary>
        public int TotalRs { get; set; } = 0;

        /// <summary>
        /// 设置传递PageIndex 在链接里显示的参数名，如不设置此属性默认为“page”
        /// 例如?page=1
        /// </summary>
        public string PageTxtConfig { get; set; } = "page";
        /// <summary>
        /// 设置页面上显示的上一页文本，如不设置此属性默认显示“上一页”
        /// </summary>
        public string PageTxtPreviousPageConfig { get; set; } = "上一页";
        /// <summary>
        /// 设置页面上显示的下一页文本，如不设置此属性默认显示“下一页”
        /// </summary>
        public string PageTxtNextPageConfig { get; set; } = "下一页";

        /// <summary>
        /// 设置页面上总共能显示几个页码的链接用来点击（例：4，5，6，7，8）
        /// ，如不设置此属性默认为最多显示5个
        /// </summary>
        public int ShowPageNums { get; set; } = 5;
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //返回总页数
            _totalPages = (int)Math.Ceiling(TotalRs / (double)PageSize);
            //是否有上一页
            bool hasPreviousPage = HasPreviousPage();
            //是否有下一页
            bool hasNextPage = HasNextPage();
            //设置页面上总共能显示几个页码的链接用来点击（例：4，5，6，7，8）
            //int showPages = 5;

            //生成当前页面的路径和查询字符串。
            var path = _httpContextAccessor.HttpContext.Request.Path;
            QueryString Querystring = _httpContextAccessor.HttpContext.Request.QueryString;
            

            StringBuilder pagehtml = new StringBuilder();
            
            
            //设置显示的第一页索引
            int pageIndexStart = this.PageIndex >= this.ShowPageNums ? this.PageIndex - (this.PageIndex % this.ShowPageNums) : 1;
            
            pagehtml.Append("<ul class=\"pagination\">");

            //设置上一页是否能点击
            string hasPreviousPageDisabled = HasPreviousPage() ? "" : "disabled";
            //设置返回第一页链接
            pagehtml.Append($"<li class=\"page-item {hasPreviousPageDisabled}\" ><a class=\"page-link\" href=\"{RemovePagestring(path, Querystring.Value, 1)}\"><span area-hidden=\"true\">«</span><span class=\"sr-only\">First</span></a></li>");

            //设置上一页链接
            pagehtml.Append($"<li class=\"page-item {hasPreviousPageDisabled}\" ><a class=\"page-link\" href=\"{RemovePagestring(path, Querystring.Value, PageIndex-1)}\">{this.PageTxtPreviousPageConfig}</a></li>");

            //如果 当前页码 大于等于 ShowPageNums 在最左边显示第一页链接
            if (PageIndex>=ShowPageNums)
            {
                pagehtml.Append($"<li class=\"page-item \" ><a class=\"page-link\" href=\"{RemovePagestring(path, Querystring.Value, 1)}\">1</a></li>");
                pagehtml.Append($"<li class=\"page-item disabled\" ><a class=\"page-link\" href=\"#\">…</a></li>");
            }
            for (int i = 0; i < this.ShowPageNums ; i++)
            {
                string active = (pageIndexStart + i) == PageIndex ? "active" : "";
                string currentUrlPath =RemovePagestring(path,Querystring.Value,pageIndexStart+i);
                pagehtml.Append($"<li class=\"page-item {active}\"><a class=\"page-link\" href=\"{currentUrlPath}\">{pageIndexStart+i}</a></li>");
                if (pageIndexStart + i > _totalPages-1)
                {
                    break;
                }
            }
            //设置什么时候在右边显示 最后一页的链接
            //成立条件：当前页码<（总页-(总页 取余数 一页中要显示的页码个数）)
            if (PageIndex <(_totalPages - (_totalPages % ShowPageNums)))
            {
                pagehtml.Append($"<li class=\"page-item disabled\" ><a class=\"page-link\" href=\"#\">…</a></li>");
                pagehtml.Append($"<li class=\"page-item \" ><a class=\"page-link\" href=\"{RemovePagestring(path, Querystring.Value, _totalPages)}\">{_totalPages}</a></li>");
            }
            //设置下一页是否能点击
            string hasNextDisabled = HasNextPage() ? "" : "disabled";
            pagehtml.Append($"<li class=\"page-item {hasNextDisabled}\"><a class=\"page-link\" href=\"{RemovePagestring(path, Querystring.Value, PageIndex + 1)}\">{this.PageTxtNextPageConfig}</a></li>");
            //设置最后一页链接
            pagehtml.Append($"<li class=\"page-item {hasNextDisabled}\"><a class=\"page-link\" href=\"{RemovePagestring(path, Querystring.Value, _totalPages)}\"><span area-hidden=\"true\">»</span><span class=\"sr-only\">Last</span></a></li>");
            pagehtml.Append($"<li class=\"page-item disabled\"><a class=\"page-link\">共有{this.TotalRs}条</a></li>");


            pagehtml.Append("</ul>");
            
            output.TagName = "nav";            
            output.Content.SetHtmlContent(pagehtml.ToString());
        }

        /// <summary>
        /// 是否有上一页
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public bool HasPreviousPage()
        { 
            return this.PageIndex > 1 ? true : false;
        }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public bool HasNextPage()
        {
            return this.PageIndex < this._totalPages ? true : false;
        }
        /// <summary>
        /// 移动querystring中的page=N，然后添加新的page=N 并把新的地址链接返回
        /// </summary>
        /// <param name="path">HttpContext.Request.Path</param>
        /// <param name="querystring">HttpContext.Request.QueryString.tostring()</param>
        /// <param name="pageNum">页面的索引</param>
        /// <returns></returns>
        public string RemovePagestring(string path,string querystring,int pageNum)
        {
            List<string> listQuery = new List<string>();
            if (querystring.Length > 1)
            {
                listQuery = querystring.Substring(1).Split('&', StringSplitOptions.RemoveEmptyEntries).ToList();

                if (querystring.Substring(0, 1) == "?")
                {

                    foreach (var item in listQuery)
                    {
                        if (item.StartsWith(PageTxtConfig + "="))
                        {
                            listQuery.Remove(item);
                            break;
                        }
                    }

                }
            }
            listQuery.Add($"{this.PageTxtConfig}={pageNum}");
            
            return $"{path}?{string.Join('&', listQuery)}";
        }
    }
}
