    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AccessRights,DOB,FirstName,LastName,NRIC,Nationality,StaffIdentity")]Employee employee) 
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;
                        var uploads = Path.Combine(_environment.WebRootPath, "uploads\\img\\employees");
                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse
                                (file.ContentDisposition).FileName.Trim('"');
                            System.Console.WriteLine(fileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                employee.ImageName = file.FileName;
                            }
                            
                        }
                    }
                }
                
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
                
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return View(employee);
        }
