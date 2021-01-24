    public void AddToCanvas(string text)
    {
        this.flowLayoutPanel1.Controls.Add(new Label() {Text = text});
        this.flowLayoutPanel1.Controls.Add(new TextBox());
        Resize();
    }
