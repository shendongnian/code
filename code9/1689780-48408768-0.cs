            YourObjectClass yourObjectName = new YourObjectClass();
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(YourObjectClass));
                using (TextReader reader = new StreamReader(locationString))
                {
                   yourObjectName = (YourObjectClass)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                //do whatever you need to with caught exceptions here.
            }
