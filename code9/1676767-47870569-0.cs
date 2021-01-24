    private IEnumerable<ITestInterface> GetAllOfThem(Control rootControl)
    {
        return rootControl.Controls.OfType<ITestInterface>().
               Concat(rootControls.Controls.OfType<Control>().SelectMany(GetAllOfThem));
                
    }
