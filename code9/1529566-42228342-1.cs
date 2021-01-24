    public class MyXmlManipulator
    {
        private string fileName;
        // ...
        public void ManipulateXml()
        {
            XmlDocument xmlDocument = new XmlDocument();
            using (var fs = new FileStream(fileName, FileMode.Open)
            {
                xmlDocument.Load(fs);
            }
            // ...
            // FileMode.Create will overwrite the file. No seek and truncate is needed.
            using (var fs = new FileStream(fileName, FileMode.Create)
            {
                xmlDocument.Save(fs);
            }
        }
    }
