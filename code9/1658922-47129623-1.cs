    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.IO;
    using System.Net.Http.Headers;
    namespace WebApplication6.Controllers
    {
        public class DemoController : Controller
        {
            private readonly IHostingEnvironment _environment;
    
            // Constructor
            public DemoController(IHostingEnvironment IHostingEnvironment)
            {
                _environment = IHostingEnvironment;
            }
    
            [HttpGet]
            public IActionResult Index()
            {
                return View();
            }
    
            [HttpPost]
            public IActionResult Index(string name)
            {
                var newFileName = string.Empty;
    
                if (HttpContext.Request.Form.Files != null)
                {
                    var fileName = string.Empty;
                    string PathDB = string.Empty;
    
                    var files = HttpContext.Request.Form.Files;
    
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            //Getting FileName
                            fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
    
                            //Assigning Unique Filename (Guid)
                            var myUniqueFileName = Convert.ToString(Guid.NewGuid());
    
                            //Getting file Extension
                            var FileExtension = Path.GetExtension(fileName);
    
                            // concating  FileName + FileExtension
                            newFileName = myUniqueFileName + FileExtension;
    
                            // Combines two strings into a path.
                            fileName = Path.Combine(_environment.WebRootPath, "demoImages") + $@"\{newFileName}";
    
                            // if you want to store path of folder in database
                            PathDB = "demoImages/" + newFileName;
    
                            using (FileStream fs = System.IO.File.Create(fileName))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }
                        }
                    }
    
    
                }
                return View();
            }
        }
    }
