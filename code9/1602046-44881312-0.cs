                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string serializedResult = serializer.Serialize(rawFile);
                // byte[] bytes = Encoding.Default.GetBytes(serializedResult);
                // string myString = Encoding.UTF8.GetString(bytes);
                File.WriteAllText("dump2.txt", serializedResult);
