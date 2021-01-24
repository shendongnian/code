            public static void ChooseItem<T>(this ComboBox cb, int id) where T : IDatabaseTableClass
        {
            // In order for this to work, the item you are searching for must implement IDatabaseTableClass so that this method knows for sure
            // that there will be an ID for the comparison.
            /* Enumerating over the combo box items is the only way to set the selected item.
             * We loop over the items until we find the item that matches. If we find a match,
             * we use the matched item's index to select the same item from the combo box.*/
            foreach (T item in cb.Items)
            {
                if (item.ID == id)
                {
                    cb.SelectedIndex = cb.Items.IndexOf(item);
                }
            }
        }
