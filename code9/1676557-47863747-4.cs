     public bool CheckForEmptyTextBoxes(object[] obj) {
       foreach (object ctrl in obj) {
         TextBox box = ctrl as TextBox;
         if ((box != null) && (string.IsNullOrEmpty(box.Text)))
           return true; // <- Empty TextBox found
       }  
       // We scan the entire collection and no empty TextBox has been found
       return false;
     }
