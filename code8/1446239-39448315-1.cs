        protected void Page_Load(object sender, EventArgs e)
        {
            var container = testje.ContentTemplateContainer;
            container.Controls.Clear();
            Button btn = new Button();
            btn.Text = "123";
            btn.Click += new EventHandler(btnClick);
            container.Controls.Add(btn);
        }
