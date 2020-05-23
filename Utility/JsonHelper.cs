using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace Utility
{
    public static class JSONHelper
    {
        /// <summary>
        /// 将对象转化为json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJSON(object obj)
        {
            
            return JsonConvert.SerializeObject(obj);
            
            
            

        }
        /// <summary>
        /// 将数据表转化为键值对集合
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Dictionary<string, object>> DataTableToList(DataTable dt)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    dic.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                list.Add(dic);

            }
            return list;
        }
        /// <summary>
        /// 将数据表转化为json
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJSON(DataTable dt)
        {
            return ObjectToJSON(dt);
        }
        /// <summary>
        /// 将JSON 转换为 对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        public static T JSONToObject<T>(string jsonText)
        {
            
            try
            {
                
                return JsonConvert.DeserializeObject<T>(jsonText);
            }
            catch (Exception ex)
            {

                throw new Exception("JSONHelper.JSONToObject(): " + ex.Message);
            }
        }
    }
}
