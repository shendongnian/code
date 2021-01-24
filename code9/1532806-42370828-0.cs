    public Cookie GetTokenCookie()
            {
                var webDriver = new ChromeDriver(); //or any IWebDriver
    
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
    
                Cookie cookie = default(Cookie);
    
                try
                {
                    cookie = wait.Until(driver =>
                    {
                        Cookie tokenCookie = driver.Manage().Cookies.GetCookieNamed("nameOfCookie");
                        if (tokenCookie != null)
                        {
                            Console.WriteLine("\nToken Cookie added: " + tokenCookie);
                            return tokenCookie;
                        }
                        else
                        {
                            Console.WriteLine("waiting for cookie...");
                            return null;
                        }
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                }
    
                return cookie;
            }
