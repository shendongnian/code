    picturebox.Click += picturebox_click;
    private void picturebox_click(object sender, EventArgs e)
    {
        var handler = this.Click;
        if(handler != null)
        {
            handler(this, e);
        }
    }
