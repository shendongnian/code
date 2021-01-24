        private void DisplayMenuByConstructingHtmlTags(List<string> menuList)
        {
            var menuHtml = "";
            foreach (string menuText in menuList)
            {
                menuHtml += "<a class=\"dropdown-item\" href=\"#\">" + menuText + "</a>\n";
            }
            myDropdownMenu.InnerHtml = menuHtml;
        }
