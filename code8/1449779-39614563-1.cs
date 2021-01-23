        [Serializable]
        public class TempFileCollection
        {
           private Hashtable files;
           // Other stuff...
    
           ~TempFileCollection()
           {
             if (KeepFiles) {return}
             foreach (string file in files.Keys)
             {
                File.Delete(file);
             }
           }
        }
    
       {
           "$type": "System.CodeDom.Compiler.TempFileCollection",
           "BasePath": "C:",
           "KeepFiles": "False",
           "TempDir": "Windows"
        }
 
