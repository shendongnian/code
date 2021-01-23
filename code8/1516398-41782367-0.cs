        public void CheckSeat()
        {
            CinemaDataSetTableAdapters.QueriesTableAdapter tmp = new CinemaDataSetTableAdapters.QueriesTableAdapter();
            for (int i = 0; i < SeatcheckedListBox.Items.Rows.Count; i++)
            {
                if (comboBox3.SelectedValue != null)
                tmp.CheckSeat(seats[i].ToString(), Convert.ToInt32(comboBox3.SelectedValue.ToString()), ref kom);
                if (kom == "Exists")
                {
                    SeatcheckedListBox.SetItemChecked(i, true);
                }
            }
        }
