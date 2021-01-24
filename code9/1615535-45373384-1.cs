    [HttpPost]
                                [ValidateAntiForgeryToken]
                                public ActionResult Index(RegisterViewModel register)
                                {
                                    if (ModelState.IsValid)
                                    {
                                        string code = Guid.NewGuid().ToString();
    
                                        userRepo.Insert(new Models.User()
                                        {
                                            UserName = register.UserName,
                                            Email = register.Email,
                                            Password = register.Password,    
                                            Role = register.SelectedRole
                                            CreatedDate = DateTime.Now,
                                            AuthCode = code,
                                            Status = false
                                        });  
                                        SendMail(register.UserName, register.Email, code);
                                        return RedirectToAction("Thankyou");
                                    } 
                                    return View(register);
                                }
