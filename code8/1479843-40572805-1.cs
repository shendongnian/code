    public void Remove(Form g)
    {
        var toRemove = g.Controls.OfType<Button>().Where(x => x.Name != "btn_reset").ToList();
        foreach(Button b in toRemove)
        {
            g.Controls.Remove(b);
        }
    }
