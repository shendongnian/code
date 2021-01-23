            private void PlanningDataGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Tab)
            {
                try
                {
                    if (PlanningDataGrid.FindVisualChildByName<ComboBox>("EventTypeComboBox") != null)
                    {
                        Keyboard.Focus(PlanningDataGrid.FindVisualChildByName<ComboBox>("EventTypeComboBox"));
                    }
                    if (PlanningDataGrid.FindVisualChildByName<ComboBox>("shopСomboBox") != null)
                    {
                        Keyboard.Focus(PlanningDataGrid.FindVisualChildByName<ComboBox>("shopСomboBox"));
                    }
                    if (PlanningDataGrid.FindVisualChildByName<ComboBox>("oilfieldСomboBox") != null)
                    {
                        Keyboard.Focus(PlanningDataGrid.FindVisualChildByName<ComboBox>("oilfieldСomboBox"));
                    }
                    if (PlanningDataGrid.FindVisualChildByName<ComboBox>("wellClusterСomboBox") != null)
                    {
                        Keyboard.Focus(PlanningDataGrid.FindVisualChildByName<ComboBox>("wellClusterСomboBox"));
                    }
                    if (PlanningDataGrid.FindVisualChildByName<ComboBox>("oilWellСomboBox") != null)
                    {
                        Keyboard.Focus(PlanningDataGrid.FindVisualChildByName<ComboBox>("oilWellСomboBox"));
                    }
                    //if ()
                }
                catch (Exception) { }
            }
        }
