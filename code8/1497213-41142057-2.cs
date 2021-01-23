        IEnumerable<Menu> GetActiveMenus(Menu menu)
        {
            if (menu.IsActive)
            {
                yield return menu;
            }
            if (menu.Children == null)
            {
                yield break;
            }
            foreach (var child in menu.Children)
            {
                foreach (var item in GetActiveMenus(child))
                {
                    yield return item;
                }
            }
        }
