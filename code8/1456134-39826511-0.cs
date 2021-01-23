      XmlSerializer serializer = new XmlSerializer(typeof(List<News>));
            using (TextWriter writer = new StreamWriter(@"D:\News.xml"))
            {
                serializer.Serialize(writer, _newsList);
            }
 
