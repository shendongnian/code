            string[] items = selectedItems.Split(',');
            for (int i = 0; i < checkBoxListLCourse.Items.Count; i++)
             {
                if (items.Contains(checkBoxListLCourse.Items[i].Value))
                {
                  checkBoxListLCourse.Items[i].Selected = true;
                }
             }
