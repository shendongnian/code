            public ActionResult CreatePeople()
            {
                return View();
            }
            [HttpPost]
            public ActionResult CreatePeople(Person person,string city,string code , int number)
            {
                if (person.TheSameAddress == true )
                {
                    var newperson = new Person
                    {
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                         BirthDate= DateTime.Now,
                        TheSameAddress=person.TheSameAddress                                                
                    };
                    db.person.Add(newperson);
                    db.SaveChanges();
                    var newRegisterAdress = new RegisteredAddress
                    {
                        City = city,
                        Code = code,
                        Number = number,
                        Person = newperson
                    };
                    db.RegisteredAddress.Add(newRegisterAdress);
                    db.SaveChanges();
                    var newAdressCorrsp = new AddressCorrespondence
                    {
                        City = city,
                        Code = code,
                        Number = number,
                        Person = newperson
                    };
                    db.AddressCorrespondence.Add(newAdressCorrsp);
                    db.SaveChanges();
                }
                else
                {
                    var newperson = new Person
                    {
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        BirthDate = DateTime.Now,
                        TheSameAddress=person.TheSameAddress
                    };
                    db.person.Add(newperson);
                    var newRegisterAdress = new RegisteredAddress
                    {
                        City = city,
                        Code = code,
                        Number = number,
                        Person = newperson
                    };
                    db.RegisteredAddress.Add(newRegisterAdress);
                    db.SaveChanges();
                }
                return View();
            }
