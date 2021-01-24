    IWebElement comboBox = new WebDriverWait(_browserWindow, TimeSpan.FromSeconds(30)).Until(d => _browserWindow.FindElement(By.Id(id)));
                    SelectElement dropdownList = new SelectElement(comboBox);
                    int j = 0;
                    for (int i = 0; i < newList.Length; i++)
                    {
                        if (dropdownList.Options[i].Text == "")
                        {
                            continue; //if drop down contain 1st value as blank
                        }
                        if (dropdownList.Options[i].Text == newList[j])
                        {
                            j++;
                            Console.WriteLine("Value Matched");
                        }
                        else
                        {
                            throw new Exception("Data not found");
                        }
                    }
