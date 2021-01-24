        public void Collapse()
        {
            _width = _body.Width;
            _height = _body.Height;
            _body.Dock = DockStyle.None;
            _body.Width = 0;
            _body.Height = 0;
            _headerButton.Image = UpIcon;
            _isCollapsed = true;
        }
        public void Expand()
        {
            _body.Width = _width;
            _body.Height = _height;
            _body.Dock = DockStyle.Fill;
            _headerButton.Image = DownIcon;
            _isCollapsed = false;
        }
