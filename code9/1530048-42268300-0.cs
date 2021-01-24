        namespace Project.Classes
        {
             public static class DGV_Handler
             {
                 public static DataGridViewComboBoxColumn CreateInventoryComboBox()
                 {
                      DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                      // This lets the combo box display the data selected
                      // I set the datasource with new instance because if i use the Datasource used in the combobox in the item selection. the combobox in the grid and that combox will be binded. if i change one combobox the other one follows.
                      combo.DataSource = new Inventory().read_inventory();
                      combo.DataPropertyName = "inventory_id";
                      combo.DisplayMember = "name";
                      combo.ValueMember = "inventory_id";
                      combo.Name = "inventory_id";
                      combo.HeaderText = "Code";
                      combo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                      return combo;
                }
                public static DataGridViewComboBoxColumn CreateGLAccountComboBox()
                {
                      DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                      combo.DataSource = new Account().read();
                      combo.DataPropertyName = "gl_account_sales";
                      combo.DisplayMember = "account_name";
                      combo.ValueMember = "account_id";
                      combo.Name = "account_id";
                      combo.HeaderText = "Account";
                      combo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                      return combo;
               }
               public static DataGridViewTextBoxColumn CreateTextBox(string dataproperty, string headertext, string name, bool is_numbers)
               {
                     DataGridViewTextBoxColumn textbox = new DataGridViewTextBoxColumn();
                     textbox.DataPropertyName = dataproperty;
                     textbox.HeaderText = headertext;
                     textbox.Name = name;
                    if (is_numbers)
                    {
                       textbox.DefaultCellStyle.Format = "0.00";
                       textbox.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }            
                    return textbox;
               }
           }
        }
