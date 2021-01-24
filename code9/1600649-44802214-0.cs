     /// <summary>
        ///  Finds common folder for a string array of file and folder paths. 
        ///  eg for input
        ///         C:\Users\Simon\Documents\File.doc
        ///         C:\Users\Simon\Documents\TestFolder\File.doc
        ///         C:\Users\Simon\Documents\TestFolder\File2.doc
        ///         C:\Users\Simon\Documents\TestFolder\Subfolder1
        ///         
        /// Output is
        ///         C:\Users\Simon\Documents
        /// </summary>
        /// <param name="Selection"> array of paths</param>
        /// <returns>common folder path or null if none</returns>
        private string FindCommonFolder(string[] Selection)
        {
          
            string[] SplitItem;
            List<string[]> ItemList = new List<string[]>();
            foreach (string Item in Selection)
            {
                string[] ItemElements = new string[40];
                SplitItem = Item.Split('\\');
                int i = 0;
                foreach (string Element in SplitItem)
                {
                    ItemElements[i] = Element;
                    i++;
                }
                ItemList.Add(ItemElements);
            }
            string sCommonFolder = "";
            for (int i = 0; i < 39; i++)
            {
                string Element = ItemList[0][i];
         
                if (Element != null)
                {
                    foreach (string[] ListElements in ItemList)
                    {
                        if (ListElements[i] != Element)
                        {
                            if (i == 0) return null;
                            else return sCommonFolder.Substring(0, sCommonFolder.Length - 1);
                        }
                    }
                    sCommonFolder += Element + '\\';
                }
            }
            return sCommonFolder.Substring(0, sCommonFolder.Length - 1);
        } 
