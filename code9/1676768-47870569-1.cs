    private IEnumerable<ITestInterface> GetAllOfThem(Control rootControl)
    {
        return rootControl.Controls.OfType<ITestInterface>().
               Concat(rootControl.Controls.OfType<Control>().SelectMany(GetAllOfThem));
                
    }
