    static async void getJobject(string jsonstring)
            {
                JObject response = await JObject.Parse(jsonstring);
                foreach (var node in response.Children())
                {
                    Console.WriteLine(node.Path);
                    string propertyPath = node.Path + ".screenshot.thumbnailUrl";
                    var token = response.SelectToken(propertyPath);
    
                    if (token != null)
                    {
                        Console.WriteLine("Check this=> " + token.ToString()); //Prints screenshot URL from weather
                    }
                    else
                    {
                        propertyPath = node.Path + ".value";
                        token = response.SelectToken(propertyPath);
                        if (token != null)
                        {
                            int count = token.Children().Count();
                            for (int i = 0; i < count; i++)
                            {
                                propertyPath = node.Path + ".value" + "[" + i.ToString() + "]" + ".screenshot.thumbnailUrl";
                                var mytoken = response.SelectToken(propertyPath);
                                if (mytoken != null)
                                {
                                    Console.WriteLine("Check this=> " + mytoken.ToString()); //Prints screenshot URL from entities
                                }
                            }
    
    
                        }
                    }
    
                }
            }
