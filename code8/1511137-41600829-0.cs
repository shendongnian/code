     List<CheckBox> cbList = new List<CheckBox>();
     for (int i = 0; i < 10; i++)
     {
        CheckBox cb = new CheckBox();
        cb.ID = "DynamicCb" + i";
        cb.ClientIDMode = ClientIDMode.Static;
        cb.Text = "text" + i;
        pnlEmailCheckboxes.Controls.AddAt(0, cb);
        pnlEmailCheckboxes.Controls.AddAt(0, new LiteralControl("<br/>"));
        cbList.Add(cb);
     }
