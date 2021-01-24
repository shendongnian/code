            ListBoxItem testitem = preferenceType.SelectedValue as ListBoxItem;
            string name = foodName.Text;
            string type = testitem.Content.ToString();
            Preference newPreference = new Preference(name, type);
            string temp = name + ";" + type;
            newPreference.save(temp, newPreference.path);
            MessageBox.Show(name + type + "saved");
