    public void RemoveTextBoxes()
    {
        RemoveTextBoxes(Controls);
    }
    private void RemoveTextBoxes(Control.ControlCollection controls)
    {
        if(controls == null) 
            return;
        for(int i = 0; i < controls.Count; ++i)
        {
            var control = controls[i];
            if(control is TextBox)
                controls.RemoveAt(i);
            else 
                RemoveTextBoxes(control?.Controls);
        }
    }
