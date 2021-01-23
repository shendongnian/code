     private void checkTextBoxes(){
        List<string> textValues = new List<string>();
        bool emptyFound = false;
        for(int i=1;i<21;i++){
           TextBox t = this.Controls.Find("TextBox"+i.ToString(),true)[0] as TextBox;
           //use parent control if you have one ex: Panel1.Controls.Find
           if(t.Text.Length==0){
               emptyFound=true;
               break;
           }
           textValues.Add(t.Text);
        }
        if(emptyFound){
            MessageBox.Show("You left a textbox blank");
        }else{
            MessageBox.Show("You entered values:\n"+String.Join("\n",textValues));
        }
     }
