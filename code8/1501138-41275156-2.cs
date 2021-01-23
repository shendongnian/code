         //Gets a list of all ticked checkboxes
         public List<Control> CheckForChecked()
            {
                var tabPage1 = new TabPage();
                var results = new List<Control>(0);
                results.AddRange(from Control c in tabPage1.Controls
                                 where c is CheckBox && (c as CheckBox).Checked
                                 select c);
                return results;
            }
          //The button click. Loop through elements and remove ones with the right name
          private void button2_Click(object sender, System.EventArgs e)
          {
              var toDelete = CheckForChecked();
              var tabPage1 = new TabPage();
              foreach (var val in toDelete.Where(val => tabPage1.Controls.Contains(val)))
              {
                  tabPage1.Controls.Remove(val);
              }
          }        
        
