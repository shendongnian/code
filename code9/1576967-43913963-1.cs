    //load the values:
    string [] alllines = System.IO.File.ReadAllLines("yourPath");
    List<TextBox> allTextboxes = this.Controls.OfType<TextBox>().ToList();
    for (int i = 0; i < allTextboxes.Count; i++)
    {
        allTextboxes[i].Text = alllines[i];
    }
