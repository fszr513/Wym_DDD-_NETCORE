using Application.WebUserApp;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Web.Controllers
{
    public class WebUsersController : Controller
    {
        //private readonly WebContext _context;
        private readonly IWebUserService _webUser;
        public WebUsersController(IWebUserService webUser)
        {
            //_context = context;
            _webUser = webUser;
        }

        // GET: WebUsers
        public IActionResult Index(int pageindex=1,int pagesize=10,int total = 0)
        {
            pagesize = pagesize > 60 ? 60 : pagesize;
            if (pageindex==1)
            {
                //ViewBag.total = _webUser.getCount();
                ViewBag.total = _webUser.getcount();
            }
            else
            {
                ViewBag.total = total;
            }
            
            ViewBag.pageindex = pageindex;
            ViewBag.pagesize = pagesize;
            return View(_webUser.getallbypage(pageindex,pagesize));
        }

        //GET: WebUsers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webUser = _webUser.firstordefault(m => m.Id == id,true);
            if (webUser == null)
            {
                return NotFound();
            }

            return View(webUser);
        }

        //GET: WebUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WebUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,LogUserId,LogUserPassword,RegTime,RegIp,LoginIp,ErrorLoginCount,IsLock,LockTime,Token")] WebUser webUser)
        {
            if (ModelState.IsValid)
            {
                _webUser.add(webUser);
                
                return RedirectToAction(nameof(Index));
            }
            return View(webUser);
        }

        // GET: WebUsers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webUser =_webUser.find(id??0);
            if (webUser == null)
            {
                return NotFound();
            }
            return View(webUser);
        }

        // POST: WebUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,LogUserId,LogUserPassword,RegTime,RegIp,LoginIp,ErrorLoginCount,IsLock,LockTime,Token")] WebUser webUser)
        {
            if (id != webUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _webUser.update(webUser);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebUserExists(webUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(webUser);
        }

        // GET: WebUsers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webUser = _webUser.firstordefault(c => c.Id == id, false);
            if (webUser == null)
            {
                return NotFound();
            }

            return View(webUser);
        }

        // POST: WebUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var webUser = _webUser.find(id);
            _webUser.delete(webUser);
            
            return RedirectToAction(nameof(Index));
        }

        private bool WebUserExists(int id)
        {
            return _webUser.any(e => e.Id == id);
        }
    }
}
