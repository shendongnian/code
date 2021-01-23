        var partialView = RenderPartialViewToString("_EmailView",
                            new EmailViewModel()
                            {
                                Email = user.Email,
                                UserName = user.UserName,
                                ...
                            });
