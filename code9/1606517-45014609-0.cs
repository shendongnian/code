    public void Collapse()
    {
        _body.Visible = false;
        _headerButton.Image = UpIcon;
        _isCollapsed = true;
    }
    public void Expand()
    {
        _body.Visible = true;
        _headerButton.Image = DownIcon;
        _isCollapsed = false;
    }
