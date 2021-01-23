    var loginHistory= db.Users.Select(u=>new UserSearchResults
                                        {
                                            UserName = user.UserName,
                                            FirstName = user.FirstName,
                                            LastName = user.LastName,
                                            Email = user.Email,
                                            IsActive = user.Active,
                                            LastLoginDate=user.LogonHistory
                                                              .OrderByDescending(e=>e.LoginDate)
                                                              .FirstOrDefault().LoginDate
                                         } );
