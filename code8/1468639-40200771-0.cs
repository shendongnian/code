     private void onClickRemove(object sender, EventArgs e)
     {
         var textBoxToRemove = inputTextBoxes.LastOrDefault();
         // or
         // var textBoxToRemove = inputTextBoxes.FirstOrDefault();
         if (textBoxToRemove != null)
         {
             this.Controls.Remove(textBoxToRemove);
             inputTextBoxes.Remove(textBoxToRemove);
         }
     }
