      public bool loadImageList(string baseUri)
      {
        imageList = System.IO.File.ReadAllText(GetFilePath(baseUri, "images.txt"));
        return true;
      }
      public bool inImageList(string str)
      {
        return imageList.Contains("\r\n" + str + "\r\n");
      }
        public string GetBaseUri(XPathNavigator node) {
          return node.BaseURI;
        }
        
        public string GetFilePath(string baseUri, string fileName) {
          return new Uri(new Uri(baseUri), fileName).LocalPath;
        }
    ]]>
