     string[] operators = new string[] {"+","-","*","/"};//all operators   
     private void Btn_Click(Object sender,EventArgs e)
            {
              string str=yourtextBox.Text;
              string lastChar = str.Substring((str.Length - 1), 1);// get last caracter
              if (operators.Contains(lastChar))
                 {
                
                 }
              else
                 {
                  //your code
                 }
            }
