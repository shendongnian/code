    while(driver.FindElement(By.Id("Captcha")).GetCssValue("display").ToString().Trim() == "block")
                        { 
                    ITakesScreenshot ssdriver = driver as ITakesScreenshot;
                    byte[] screenshot = ssdriver.GetScreenshot().AsByteArray;
                    MemoryStream ms = new MemoryStream(screenshot);
                    IWebElement my_image = driver.FindElement(By.XPath("//*[@id=\"Captcha\"]/img"));
                    Point point = my_image.Location;
                    int width = my_image.Size.Width;
                    int height = my_image.Size.Height;
                    Rectangle section = new Rectangle(point, new Size(width, height));
                    Bitmap originalScreenshot = (Bitmap)Bitmap.FromStream(ms);
                    Bitmap final_image = CropImage(originalScreenshot, section);
                    MemoryStream ms2 = new MemoryStream();
                    final_image.Save(ms2, ImageFormat.Png);
                    byte[] captchaimage = ms2.ToArray();
                    Image image = Image.FromStream(ms2);
                    image.Save(@"C:\Users\bulut\Desktop\testcaptcha.png");
                    OcrEngine ocrEngine = new OcrEngine();
                    ocrEngine.Image = ImageStream.FromStream(ms2, ImageStreamFormat.Png);
                    string SolvedCaptcha = "";
                    if (ocrEngine.Process())
                    {
                        string OcrCaptcha = ocrEngine.Text.ToString().Trim();
                        SolvedCaptcha = Regex.Replace(OcrCaptcha, "[^a-zA-Z0-9]", "").Trim();
                    }
                    var script = "document.getElementById('ContentPlaceHolder1_txtCaptcha').value = '';";
                    IWebElement element = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript(script);
                    IWebElement captcha = driver.FindElement(By.XPath("//*[@id=\"ContentPlaceHolder1_txtCaptcha\"]"));
                    captcha.SendKeys(SolvedCaptcha);
                    captcha.SendKeys(Keys.Enter);
                        var wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                        wait5.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
                        Thread.Sleep(2000);
                }
