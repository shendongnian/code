        public Control AddNewTab2()
        {
            Control hostControl = new Control { Dock = DockStyle.Fill };
            TabPage tab = new TabPage();
            tab.Controls.Add(hostControl);
            this.tabControl1.Invoke(new Action(() => { this.tabControl1.Controls.Add(tab); }));
            return hostControl;
        }
