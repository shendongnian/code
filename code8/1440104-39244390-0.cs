    public IEnumerable<GroupBoxes> GetAllGroupBoxes(Control c)
    {
        return c.Controls.OfType<GroupBox>()
                         .Concat(c.Controls.OfType<Control>().SelectMany(GetAllGroupBoxes));
    }
    List<GroupBox> gBoxes = GetAllGroupBoxes(this);
