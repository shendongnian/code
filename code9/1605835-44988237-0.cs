    private void _valueIsSet = false;
    private void Placeholder_Hide(object sender, EventArgs e)
    {
        if (!this._valueIsSet)
        {
            this.Text = "";
            this.ForeColor = Color.Black;
            this.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular);
        }
    }
    private void Placeholder_Show(object sender, EventArgs e)
    {
        if (this.IsEmpty())
        {
            this._valueIsSet = false;
            this.Text = this._placeholder;
            this.ForeColor = Color.Gray;
            this.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
        }
    }
