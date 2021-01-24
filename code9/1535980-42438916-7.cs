     var root = new Root();
     root.Content = new List<Content>();
     root.Content.Add(new Content { UId = "1", FileName = "file1.jpg" });
     root.Content.Add(new Content { UId = "2", FileName = "file2.jpg" });
     var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Root));
     serializer.Serialize(File.Create(@"C:\temp\file.xml"), root);
