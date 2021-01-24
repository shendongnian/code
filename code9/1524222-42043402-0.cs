                string strComment = "";
                Random rndom = new Random();
                List<string> strResult = new List<string>();
                while (strResult.Count != userNames.Count) //Making sure every userNames is added
                {
                    int a = rndom.Next(0, userNames.Count);
                    if (!strResult.Contains(userNames.ElementAt(a))) //Making sure no duplicates
                        strResult.Add(userNames.ElementAt(a));
                    
                }
                strComment = string.Join(" ", strResult); //Will return all results with space.
            
