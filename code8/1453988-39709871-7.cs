            public ActionResult CreateAdress(int Id_Person )
            {
                ViewBag.PersonId = Id_Person;
                return View();
            }
            [HttpPost]
            public ActionResult CreateAdress(RegisteredAddress ra ,int Id_Person)
            {
                var personf = db.person.Find(Id_Person);
                if (personf.TheSameAddress == true)
                {
                    var newRegisterAdress = new RegisteredAddress
                    {
                        City = ra.City ,
                        Code = ra.Code,
                        Number = ra.Number,
                        Person = personf
                    };
                    db.RegisteredAddress.Add(newRegisterAdress);
                    db.SaveChanges();
                    var newAdressCorrsp = new AddressCorrespondence
                    {
                        City = ra.City,
                        Code = ra.Code,
                        Number = ra.Number,
                        Person = personf
                    };
                    db.AddressCorrespondence.Add(newAdressCorrsp);
                    db.SaveChanges();
                }
                else
                {
                    var newRegisterAdress = new RegisteredAddress
                    {
                        City = ra.City,
                        Code = ra.Code,
                        Number = ra.Number,
                        Person = personf
                    };
                    db.RegisteredAddress.Add(newRegisterAdress);
                    db.SaveChanges();
                }
                return RedirectToAction("People");
            }
