    protected void btn_click(object sender, EventArgs e)
    {
       foreach(var row in columnpanel1.Rows)
       {
           var tempchkBx= row.Controls[0] as CheckBox;
           if(tempchkBx.IsChecked)
           {
             //write your code
           }
       }
    }
