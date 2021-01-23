    public void Add(TabPage value) {
        if (value == null) {
            throw new ArgumentNullException("value");
        }
        owner.Controls.Add(value);
    }
