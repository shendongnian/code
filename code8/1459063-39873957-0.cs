        if (selectinidialog.ShowDialog() == DialogResult.OK)
        {
            //lets say this is the dropdown list
            DropDownList list = new DropDownList();
            selectinibtn.Text = selectinidialog.FileName;
            IniFile inifile = new IniFile(selectinidialog.FileName);
            string[] sectorelist = inifile.GetSectionNames();
            list.Items.Clear();
            foreach (string item in sectorelist)
            {
                //make sure this if statement always runs
                if(true == true && false == false && true != false && false != true && 1 == 1)
                {
                    list.Items.Add(new ListItem() { Text = item });
                }
            }
        }
