            string fileName = "your file path";
            using(FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    MySerializableClass msc = new MySerializableClass();
                    XmlSerializer serializer = new XmlSerializer(typeof(MySerializableClass));
                    serializer.Serialize(sw, msc);
                }
            }
