        private List<Panel> Pages { get; } = new List<Panel>();
        public Panel CurrentPage
        {
            get
            {
                return Pages.Last();
            }
        }
        public void ShowPage(Panel page)
        {
            Pages.Add(page);
            foreach (var panel in Controls.OfType<Panel>())
            {
                if (panel.Dock == DockStyle.Fill)
                    panel.Visible = false;
            }
            page.Visible = true;
        }
        public void HidePage()
        {
            if (CurrentPage != null)
                CurrentPage.Visible = false;
            Pages.RemoveAt(Pages.Count - 1);
            if (CurrentPage != null)
                CurrentPage.Visible = true;
        }
