           public async Task<IActionResult> XmlPage(IFormFile xmlFile)
        {
            var uploads = hostingEnvironment.WebRootPath;
            var filePath = Path.Combine(uploads, xmlFile.FileName).ToString();
            
            if (xmlFile.ContentType.Equals("application/xml") || xmlFile.ContentType.Equals("text/xml"))
            {
                try
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await xmlFile.CopyToAsync(fileStream);
                        fileStream.Dispose();
                        XDocument xDoc = XDocument.Load(filePath);
                        List<DmgRegisterVM> dmgRegistterList = xDoc.Descendants("Claim").Select(dmgReg =>
                        new DmgRegisterVM
                        {
                            Uwyear = dmgReg.Element("UWYear").Value,
                            ClaimNo = dmgReg.Element("ClaimNo").Value,
                            PolicyNo = dmgReg.Element("PolicyNo").Value,
                            PolicyName = dmgReg.Element("PolicyHolder").Value,
                            Address1 = dmgReg.Element("Address1").Value,
                            Address2 = dmgReg.Element("Addresstype").Value,
                            PostalLocation = dmgReg.Element("City").Value,
                            Country = dmgReg.Element("Country").Value,
                            PostalCode = dmgReg.Element("Postalzone").Value
                        }).ToList();
                        context.SaveXmlToDb(dmgRegistterList);
                    }
                }
                catch(Exception e)
                {
                        ViewBag.Error = "Converting fail";
                }
            }
            else
            {
                ViewBag.Error = "Uploading fail";
            }
            return View("Index");
        }
