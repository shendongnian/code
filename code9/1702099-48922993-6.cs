        private void LoadMenuByAddingChildControls(List<string> menuList)
        {
            foreach (string menuText in menuList)
            {
                var linkMenu = new HyperLink() { CssClass = "dropdown-item", NavigateUrl = "#", Text = menuText };
                myDropdownMenu.Controls.Add(linkMenu);
            }
        }
