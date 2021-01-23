        if (CategorylistBox.SelectedItems != null)
            {
                foreach (var item in CategorylistBox.SelectedItem.ToString())
                {
                    Debug.WriteLine("current item "+item);
                   // CinemaDataSetTableAdapters.QueriesTableAdapter kTyp = new CinemaDataSetTableAdapters.QueriesTableAdapter();
                   // kTyp.AddCategoryType((selectedItem), TitleTextBox.Text);
                }
            }
