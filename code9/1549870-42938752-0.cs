    private void blablabla()
    {
        for (int i = 1; i < count + 1; i++)
        {
            int item_number = panelBoats.Controls.Count;
            CheckBox chb = new CheckBox();
            chb.Name = "CheckBoxBoat" + i.ToString();
            chb.Text = "Boat " + i.ToString();
            chb.Location = new Point(10, item_number * 15);
            panelBoats.Controls.Add(chb);
            //Add the checkBox to the list
            myCheckBoxList.add(chb);
        }
    }
