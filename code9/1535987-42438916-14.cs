       var r = new root();
       r.Content = new rootContent[2];
       r.Content[0] = new rootContent() { UId = 1, FileName = "file1.jpg" };
       r.Content[1] = new rootContent() { UId = 2, FileName = "file2.jpg" };
       var serializer = new System.Xml.Serialization.XmlSerializer(typeof(root));
       serializer.Serialize(File.Create(@"C:\temp\file.xml"), r);
