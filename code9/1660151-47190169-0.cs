            dgv.Columns.Add(new DataGridViewTextBoxColumn());
            dgv.Rows.Add("text" );
            dgv.EditingControlShowing += (sender, args) =>
                                         {
                                             dgv.EditingControl
                                                .TextChanged += (o, eventArgs) =>
                                                                {
                                                                    /*String being input*/
                                                                    Debug.Print(((TextBox)o).Text);
                                                                };
                                         };
