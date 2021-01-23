    this.yourButton.MouseHover += new System.EventHandler(this.yourButton_MouseHover);
    // ...
    private void yourButton_MouseHover(object sender, System.EventArgs e)
    {
        tB1.Text += "#";
    }
