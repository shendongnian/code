    Thread thread = new Thread(() =>
    {
         this.InvokeBy(() =>
         {
               tag = true;
               while (tag)
               {
                   string value = readDataFromPort();
                   //I'm still not sure about the above method, what would be the value of 
                   //control IDENTIFIER you might get 
                   //along with the packet. As you said in the comments using:
                   //"controlX.updateValue = readData.controlX()",
                   //you can differentiate controls with their respective packets.
                   //So let'say you get the Control's NAME as IDENTIFIER, then:
                   string controlName = "Control Name goes here";
                   var controls = this.Controls;
                   //you can use Controls.OfType<Label>() to spefically 
                   //pick a certain type of control from the UI
                   foreach (Control control in controls)
                   {
                       if (control.Name == controlName)
                       {
                            control.InvokeBy(() =>
                            {
                                 //replace this with database object of the control
                                 databaseObj.lable1 = value;
                                  
                                 //If you've got some other differentiation to be
                                 //used among the controls, implement if-else conditions
                                 //and then update their respective value
                                 control.Text = value;
                            });
                       }
                   }
               }
           });
       });
    thread.SetApartmentState(ApartmentState.STA);
    thread.Start();
    
   
