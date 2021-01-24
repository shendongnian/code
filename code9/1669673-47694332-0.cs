     for (int i = 0; i < Int32.Parse(inputArgs[1]); i++)
                {
                    try
                    {
                        element = driver.FindElement(By.XPath(inputArgs[0]));
                        break;
                    }
                    catch
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                }
                element = driver.FindElement(By.XPath(inputArgs[0]));
      
      }
