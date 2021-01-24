        try
                        {
                            XDocument doc = XDocument.Load(@"C:\Sample.xml");
                            foreach (var files in doc.Descendants("names"))
                            {
    //remember value will be null if the attribute is missing
    //to present the values it is going to be 
     Console.WriteLine("File Name : " + (string)files.Attribute("name") + ", File Author :" + (string)files.Attribute("author") + ", File Version : " + (string)files.Attribute("version"));
    //if you want to set a specific attribute                           
                                if ((string)files.Attribute("name") == "Example")
                                {
                                    task.SetAttributeValue("author", "Example Author");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                           //your exception here
                        }
