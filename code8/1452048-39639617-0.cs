       string value = "";
       bool isChecked = radioButton1.Checked;
       if(isChecked )
       value=radioButton1.Text;
       else
       value=radioButton2.Text;
       MessageBox.show("Welcome " + value + "How are you?");
