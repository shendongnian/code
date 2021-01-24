                        if (Request.Cookies["UserSettings"] != null)
                        {
                            HttpContext.Current.Response.Cookies.Remove("UserSettings");
                            HttpCookie myCookie = new HttpCookie("UserSettings");
                            myCookie.Expires = DateTime.Now.AddDays(-1d);
                            myCookie.Value = null;
                            HttpContext.Current.Response.SetCookie(myCookie);
                        }
