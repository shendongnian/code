    if (textValue == "HAAN SHI") 
         { 
           txtname.Text = ("HAAN SHI");
           txtposition.Text = ("INTERN");
           txtjobscope.Text= ("LEARN");
         }
    else if (textValue == "Others") 
         { 
         ... code // do something ... 
         }
    else 
         { 
           txtname.Clear();
           txtposition.Clear();
           txtjobscope.Clear();
           MessageBox.Show("THE NAME THAT YOU TYPE IN IS NOT IN THE DATABASE"); 
         }
