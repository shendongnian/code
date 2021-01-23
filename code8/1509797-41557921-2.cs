    public static IHtmlString BreadCrumbs(
            this HtmlHelper helper,
            ContentReference currentPage,
            Func<MenuItemViewModel, HelperResult> itemTemplate = null,
            bool includeCurrentPage = true,
            bool requireVisibleInMenu = true,
            bool requirePageTemplate = true)
        {
            itemTemplate = itemTemplate ?? GetDefaultItemTemplate(helper);
            Func<IEnumerable<PageData>, IEnumerable<PageData>> filter = GetFilter(requireVisibleInMenu, requirePageTemplate);
            var menuItems = new List<MenuItemViewModel>();
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var currentPageData = contentLoader.Get<PageData>(currentPage);
            ContentReference parentLink = currentPageData.ParentLink;
            if (includeCurrentPage)
                menuItems.Add(CreateBreadCrumb(currentPageData, currentPage, contentLoader, filter));
            var pages = new List<PageData>();
            do
            {
                var page = contentLoader.Get<PageData>(parentLink);
                pages.Add(page);
                parentLink = page.ParentLink;
            } while (!parentLink.Equals(ContentReference.RootPage));
            menuItems.AddRange(
                pages.FilterForDisplay(requirePageTemplate, requireVisibleInMenu)
                    .Select(page => CreateBreadCrumb(page, currentPage, contentLoader, filter)));
            menuItems.Reverse();
            return menuItems.List(itemTemplate);
        }
        private static Func<IEnumerable<PageData>, IEnumerable<PageData>> GetFilter(bool requireVisibleInMenu, bool requirePageTemplate)
        {
            return pages => pages.FilterForDisplay(requirePageTemplate, requireVisibleInMenu);
        }
