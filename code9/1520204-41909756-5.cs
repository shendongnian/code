    //visiblity
    rdbtn1.Visible = true;
    DropDownList1.Visible = false;
    DropDownList1.Visible = false;
    
    if(rdbtn1.Checked == true)
       { 
         DropDownList1.Visible = true;
         rdbtn1.Visible = false;
       } 
    else if(DropDownList1.SelectedValue != 0)
       { 
         DropDownList1.Visible = false;
         DropDownList2.Visible = true; 
       }
    else if(DropDownList2.SelectedValue != 0)
       { 
         //Totally get all your ur controls hidden in this state
         DropDownList2.Visible = false;
       }
