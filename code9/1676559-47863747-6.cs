         ...
         if (ctrl is TextBox)
         {
             if ((TextBox)ctrl.TextLength == 0)
             {
                 QEmptyTextBox = true;  // <- please, notice absence of "break"
             }
             else
             {
                 // this assigment can well overwrite empty TextBox found
                 QEmptyTextBox = false; 
             }
         }
         ...
