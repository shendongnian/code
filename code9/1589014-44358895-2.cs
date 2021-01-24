    private List<Control> GetAllControls(Control parent)
    {
        List<Control> controls = new List<Control>();
        controls.AddRange(parent.Controls.Cast<Control>()); //add all controls directly being on the current control
        controls.AddRange(parent.Controls.Cast<Control>().SelectMany(GetAllControls)); //add all children from each control
        return controls;
    }
