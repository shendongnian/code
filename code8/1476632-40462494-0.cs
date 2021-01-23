     var success = false;
     while (!success)
     {
    	try
                    {
                        HttpWebRequest URLp =(HttpWebRequest)WebRequest.Create(url);
                        URLp.Timeout = 190000;
                        URLp.Timeout = 260000;
                        URLp.ReadWriteTimeout = 260000;
                        using (WebResponse MyResponse1 = URLp.GetResponse())
                        {
                            str1 = new StreamReader(MyResponse1.GetResponseStream(), System.Text.Encoding.UTF8);
                            page1 = str1.ReadToEnd();
    						success = true;
                        }
                    }
                    catch
                    {
                        Thread.Sleep(70000);
                    }
    
     }
     
    StreamWriter stw1 = new StreamWriter(Address);
    stw1.Write(page1);
    stw1.Close();
