        public ParentForm()
        {
            InitializeComponent();
            DoubleClick += ParentForm_DoubleClick;
        }
        private void ParentForm_DoubleClick(object sender, EventArgs eventArgs)
        {
            var child = new ChildForm
            {
                TopLevel = false,
                AutoScroll = true
            };
            child.Location = new Point(
                MousePosition.X - Location.X - child.Size.Width/2,
                MousePosition.Y - Location.Y - child.Size.Height/2);
            child.Click += Child_OnClick;
            child.Closing += Child_OnClosing;
            Controls.Add(child);
            Controls.SetChildIndex(child, 0);
            child.Show();
            child.Activate();
        }
        private void Child_OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            ((ChildForm)sender).Click -= Child_OnClick;
            ((ChildForm)sender).Closing -= Child_OnClosing;
            Controls.Remove((ChildForm)sender);
        }
        private void Child_OnClick(object sender, EventArgs eventArgs)
        {
            Controls.SetChildIndex((ChildForm)sender, 0);
            ((ChildForm)sender).Activate();
        }
