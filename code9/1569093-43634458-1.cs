       using System.Globalization;
       ...
       float mont,ope,mont_ht;
    
       if (!float.TryParse(text_entrer.Text, 
                           NumberStyles.Any, 
                           CultureInfo.InvariantCulture, // or CultureInfo.CurrentCulture 
                           out mont) {
         if (text_entrer.CanFocus)
           text_entrer.Focus();
    
         MessageBox.Show($"{text_entrer.Text} is not a valid floating point value", 
                           Application.ProductName, 
                           MessageBoxButtons.OK, 
                           MessageBoxIcon.Warning);
    
         return;
       }
       ...
       if (radioButton4.Checked) 
         ...
