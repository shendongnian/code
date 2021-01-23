     using Newtonsoft.Json;
                    
                       
                public  async Task Login(string url)
                {
                List<UserDetails> ud = new List<UserDetails> ();
                    try
                    {
                        var uri = new Uri(url);
                        HttpClient myClient = new HttpClient();
                
                        var response = await myClient.GetAsync(uri);
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            JObject results = JObject.Parse (content);
                            
                            var  results2 = results ["data"];
                        
                        			foreach (var i in results2) {
                                     ud.Add (new UserDetails () {
                                      UserID = i["UserID"].ToString();
                                      RoleID = int.Parse(i["RoleID"].ToString());
                                     });
                                    }
                        }
                        else
                        {
                            Application.Current.Properties["response"] = response;
                        }
                
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }
