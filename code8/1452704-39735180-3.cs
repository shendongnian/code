    public class MyDocumentPaginator : DocumentPaginator
    {
        private List<FrameworkElement> _pages = new List<FrameworkElement>();
        public override bool IsPageCountValid  { get { return true; } }
        public override int PageCount { get { return _pages.Count; } }
        public override Size PageSize { get; set; } 
        public override IDocumentPaginatorSource Source { get { return null; } }  
        public MyDocumentPaginator(Size pageSize)
        {
            PageSize = pageSize;
        }
        public override DocumentPage GetPage(int pageNumber)
        {
            // Warning: DocumentPage remember only reference to Visual object.
            // Visual object can not be changed until PrintDialog.PrintDocument() called
            // or e.g. XpsDocumentWriter.Write().
            // That's why I don't create DocumentPage in AddPage method.
            return new DocumentPage(_pages[pageNumber], PageSize, new Rect(PageSize), new Rect(PageSize));
        }
        public void AddPage(FrameworkElement page)
        {
            _pages.Add(page);
        }
        public void AddPages(List<FrameworkElement> pages)
        {
            _pages.AddRange(pages);
        }
    }
