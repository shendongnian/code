        IWebElement comboBox = new WebDriverWait(_browserWindow, TimeSpan.FromSeconds(30)).Until(d => _browserWindow.FindElement(By.Id(id)));
                        SelectElement dropdownList = new SelectElement(comboBox);
                        int j = 0;
                        for (int i = 0; i < fullNameList.Length; i++)
                        {                            
                            if (dropdownList.Options[i].Text == passengersList[j])
                            {
                                j++;
                                Console.WriteLine("Value Matched");
                            }
                            else
                            {
                                throw new Exception("Data not found");
                            }
                        }
