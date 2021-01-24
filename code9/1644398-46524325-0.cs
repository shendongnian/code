    using System.IO;
    using System.Printing;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Media;
    
    namespace MyTextEditor
    {
        public class PrintManager
        {
            public static readonly int DPI = 96;
            private readonly RichTextBox _textBox;
    
            public PrintManager(RichTextBox textBox)
            {
                _textBox = textBox;
            }
    
            public bool Print()
            {
    
                PrintDialog dlg = new PrintDialog();
    
                if (dlg.ShowDialog() == true)
                {
    
                    PrintQueue printQueue = dlg.PrintQueue;
                    DocumentPaginator paginator = GetPaginator(
                        printQueue.UserPrintTicket.PageMediaSize.Width.Value,
                        printQueue.UserPrintTicket.PageMediaSize.Height.Value);
    
                    dlg.PrintDocument(paginator, "TextEditor Printing");
    
                    return true;
                }
    
                return false;
            }
    
            public DocumentPaginator GetPaginator(
                double pageWidth,
                double pageHeight)
            {
                TextRange originalRange = new TextRange(
                    _textBox.Document.ContentStart,
                    _textBox.Document.ContentEnd);
    
                MemoryStream memoryStream = new MemoryStream();
                originalRange.Save(memoryStream, DataFormats.Xaml);
    
                FlowDocument copy = new FlowDocument();
    
                TextRange copyRange = new TextRange(
                    copy.ContentStart,
                    copy.ContentEnd
                    );
    
                copyRange.Load(memoryStream, DataFormats.Xaml);
    
                DocumentPaginator paginator = ((IDocumentPaginatorSource)copy).DocumentPaginator;
    
                return new PrintingPaginator(
                    paginator,
                    new Size(
                        pageWidth,
                        pageHeight),
                        new Size(
                            DPI,
                            DPI));
    
    
    
            }
    
            public void PrintPreview()
            {
                PrintPreviewDialog dlg = new PrintPreviewDialog(this);
                dlg.ShowDialog();
            }
        }
    }
    /// <summary>
    /// This custom paginator wraps the original and adds some additional 
    /// functionality. Notice that many of the properties pass through to
    /// the orginal. The constructor begins by setting the original's page 
    /// size to a size reflected by the requested size and margins and then
    /// asks the underlying paginator to figure out how many pages we have.
    /// 
    /// The next function worth noting is the overide method GetPage. WPF 
    /// calls this method each time it requires a page for display or print.  
    /// </summary>
    public class PrintingPaginator : DocumentPaginator 
    {
        private readonly DocumentPaginator _originalPaginator;
        private readonly Size _pageSize;
        private readonly Size _pageMargin;
        public PrintingPaginator( DocumentPaginator paginator,
                                  Size pageSize,
                                  Size margin )
        {
            _originalPaginator = paginator;
            _pageSize = pageSize;
            _pageMargin = margin;
            _originalPaginator.PageSize = new Size(
                _pageSize.Width - _pageMargin.Width * 2,
                _pageSize.Height - _pageMargin.Height * 2);
            _originalPaginator.ComputePageCount();
        }
        public override bool IsPageCountValid
        {
            get
            {
                return _originalPaginator.IsPageCountValid;
            }
        }
        public override int PageCount
        {
            get
            {
                return _originalPaginator.PageCount;
            }
        }
        public override Size PageSize
        {
            get
            {
                return _originalPaginator.PageSize;
            }
            set
            {
                _originalPaginator.PageSize = value;
            }
        }
        public override IDocumentPaginatorSource Source
        {
            get
            {
                return _originalPaginator.Source;
            }
        }
        /// <summary>
        /// GetPage 
        /// 1. Obtain the original page form the original paginator
        /// 2. Wrap the page in a ContainerVisual, to make it easier manipulate.
        /// 3. Use a TranslateTransform to move the contents fo the ContainerVisual in line with the margins
        /// 4. Returns a new page object with its content and bleed adjusted in line with the margins
        /// </summary>
        /// <param name="pageNumber">
        /// Specifies the page number to be return by GetPage
        /// </param>
        /// <returns></returns>
        public override DocumentPage GetPage(int pageNumber)
        {
            DocumentPage originalPage = _originalPaginator.GetPage(pageNumber);
            ContainerVisual fixedPage = new ContainerVisual();
            fixedPage.Children.Add(originalPage.Visual);
            fixedPage.Transform = new TranslateTransform(
                _pageMargin.Width,
                _pageMargin.Height);
            return new DocumentPage(
                                fixedPage,
                                _pageSize,
                                AdjustForMargins(originalPage.BleedBox),
                                AdjustForMargins(originalPage.ContentBox)
                                );
        }
        private Rect AdjustForMargins(Rect rect)
        {
            if (rect.IsEmpty) return rect;
            else
            {
                return new Rect(
                                rect.Left + _pageMargin.Width,
                                rect.Top + _pageMargin.Height,
                                rect.Width,
                                rect.Height);
            }
        }
    }
