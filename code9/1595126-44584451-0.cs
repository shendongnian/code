    private bool isCheckedChange = false;
            
    public bool Change {
       get { return isCheckedChange; }
       set {
           if (isCheckedChange)
           {
               MyListBocValue = new List<string> { "String1", "String2" };
           }else{
               MyListBocValue = new List<string> { "String3", "String4" };
           }
        }
     }
    
    public List<String> MyListBocValue { get; set; }
