            string fileName = "your file path";
            using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                MySerializableClass msc = new MySerializableClass();
                XmlSerializer serializer = new XmlSerializer(typeof(MySerializableClass));
                serializer.Serialize(sw, msc);
            }
