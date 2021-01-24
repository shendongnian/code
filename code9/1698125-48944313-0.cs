     private void dtg_tabletrial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                DataGridTrialTable ff = new DataGridTrialTable();
                ff.Address = dtgtrialTable.LastOrDefault().Address;
                ff.UserName = dtgtrialTable.LastOrDefault().UserName;
                ff.Phone = dtgtrialTable.LastOrDefault().Phone;
                ff.Surname = dtgtrialTable.LastOrDefault().Surname;
                dtgtrialTable.Add(ff);
            }
        }
