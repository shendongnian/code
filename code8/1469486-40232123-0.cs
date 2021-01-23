     using (JsonTextReader reader = new JsonTextReader(file))
                {
                    while (reader.Read())
                    {
                        if (reader.Value != null)
                        {
                            key = reader.Value.ToString();
                            if (reader.Read())
                                value = reader.Value.ToString();
                            Console.WriteLine("{0} : {1}", key,value);
                            //Instead of writing in a console, process and write it in Rich text box.
                        }                        
                    }
                }
