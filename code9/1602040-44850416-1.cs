     private void button1_Click(object sender, EventArgs e)
     {
         string Target = "The Title #14 first 324.36 USD Second-GUY 261 USD Third33 101 USD";
         var value = string.Empty;
         var pattern = "(The Title) ([#]{1})([0-9]{1,500})";
    
         if (Example(Target,pattern, ref value) == true) // output: The Title #14
         {
             MessageBox.Show(value);
         }
    
         pattern = "(first) ([0-9]{1,500}(.)[0-9]{1,500})";
    
         if (Example(Target, pattern, ref value) == true) // output: first 324.36 if you want only the number one way is to replace  MessageBox.Show(value); to MessageBox.Show(value.Replace("first",""));
         {
             MessageBox.Show(value);
         }
    
         pattern = "(Second-GUY) ([0-9]{1,500}(.)[0-9]{1,500})";
    
         if (Example(Target, pattern, ref value) == true) // output: Second-GUY 261 if you want only the number one way is to replace  MessageBox.Show(value); to MessageBox.Show(value.Replace("Second-GUY",""));
         {
             MessageBox.Show(value);
         }        
     }    
    
     private bool Example(string Target,string pattern, ref string value)
     {
    
         System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(pattern);
         bool ismatched = reg.IsMatch(Target);
    
         if (ismatched)
         {
             System.Text.RegularExpressions.Match match = reg.Match(Target);
             value = match.Value;
         }
    
         return ismatched;
     }
