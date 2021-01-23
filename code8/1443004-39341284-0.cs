     public void ChangeButtonVisibility(TextBox currentText)
     {
         var arrayButtons = new Button[] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14 };
         for (int i = 0; i < arrayButtons.Length; i++)
         {
             if (currentText.Text == arrayButtons[i].Text)
             {
                 currentText.Text = "";
                 arrayButtons[i].Visible = true;
                 break;
             }
         }
     }
