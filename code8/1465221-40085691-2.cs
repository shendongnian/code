     var xDoc = MyXDocument.Load(path);
     if (xDoc != null)
     { .... 
     }
    public class MyXDocument {
        public static XDocument Load(string path) {
            try
            {
                 XDocument xDoc = XDocument.Load(path);
                 return xDoc;
            } catch(Exception) {
                return null;
            }
        }
    }
