    private void englishToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SetCulture("en-US");
    }
    private void persianToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SetCulture("fa-IR");
    }
    public void SetCulture(string cultureName)
    {
        System.Threading.Thread.CurrentThread.CurrentUICulture =
           System.Globalization.CultureInfo.GetCultureInfo(cultureName);
        var resources = new System.ComponentModel.ComponentResourceManager(this.GetType());
        GetChildren(this).ToList().ForEach(c => {
            resources.ApplyResources(c, c.Name);
        });
    }
    public IEnumerable<Control> GetChildren(Control control)
    {
        var controls = control.Controls.Cast<Control>();
        return controls.SelectMany(ctrl => GetChildren(ctrl)).Concat(controls);
    }
