     var result = await _userManager.CreateAsync(user);
           if (result.Succeeded)
           {
                result = await _userManager.AddLoginAsync(user, info);
                if (result.Succeeded)
                {
                     if (info.LoginProvider.ToLower().IndexOf("google") != -1)
                        { await _userManager.AddClaimAsync(user, new Claim("GooglePlusId", info.ProviderKey));
                            try {
                                    HttpClient client = new HttpClient();
                                    HttpResponseMessage x = await client.GetAsync($"https://www.googleapis.com/plus/v1/people/{info.ProviderKey}?fields=image&key=YOUR_GOOGLE_PLUS_API_KEY");
                                   dynamic img = Newtonsoft.Json.JsonConvert.DeserializeObject(await x.Content.ReadAsStringAsync());
                                    user.PhotoLink = img.image.url;
                                    db.SaveChanges();
                                }
                                catch { }
                                
                        }
    
                            if (info.LoginProvider.ToLower().IndexOf("facebook") != -1)
                            {
                                user.PhotoLink = $"http://graph.facebook.com/{info.ProviderKey}/picture?type=square&width=50";
                            }   
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            _logger.LogInformation(6, "User created an account using {Name} provider.", info.LoginProvider);
                            return RedirectToLocal(returnUrl);
                        }
                    }
