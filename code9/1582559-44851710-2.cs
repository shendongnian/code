    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    public class AnotherController : Controller
    {
        const string SessionKeyName = "_Name";
        const string SessionKeyFY = "_FY";
        const string SessionKeyDate = "_Date";
    
        // GET: /<controller>/
        public IActionResult Test()
        {
            ViewBag.Name = HttpContext.Session.GetString(SessionKeyName);
            ViewBag.FY = HttpContext.Session.GetInt32(SessionKeyFY);
            ViewBag.Date = HttpContext.Session.Get<DateTime>(SessionKeyDate);
    
            ViewData["Message"] = "Session State passed to different controller";
            return View();
        }
    }
