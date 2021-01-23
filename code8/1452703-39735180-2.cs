    public class PrintManager
    {
        public static readonly Size PageSizeA4 = new Size(21 * 96 / 2.54, 29.7 * 96 / 2.54); // (793.700787401575, 1122.51968503937)
        public static readonly double Size1cm = 96 / 2.54; // 37.7952755905512
        private PrintDialog _printDialog;
        public PrintTicket PrintTicket { get; private set; }
        public PrintCapabilities TicketCapabilities { get; private set; }
        // Page size selected in print dialog (may not be exactly as paper size)
        public Size PageSize { get; private set; }
        public Thickness PageMargins { get; private set; }
        public Rect PageContentRect {
            get {
                return new Rect(PageMargins.Left, PageMargins.Top,
                    PageSize.Width - PageMargins.Left - PageMargins.Right,
                    PageSize.Height - PageMargins.Top - PageMargins.Bottom);
            }
        }
        public PrintManager()
        {
        }
        /// <summary>
        /// Show print dialog or try use default printer when useDefaultPrinter param set to true.
        /// <para/>
        /// Return false on error or when user pushed Cancel.
        /// </summary>
        public bool SelectPrinter(bool useDefaultPrinter = false)
        {
            if (_printDialog == null)
                _printDialog = new PrintDialog();
            try
            {
                if (useDefaultPrinter)
                    _printDialog.PrintQueue = LocalPrintServer.GetDefaultPrintQueue();
                // pDialog.PrintQueue == null when default printer is not selected in system
                if (_printDialog.PrintQueue == null || !useDefaultPrinter)
                {
                    // Show print dialog
                    if (_printDialog.ShowDialog() != true)
                        return false;
                }
                if (_printDialog.PrintQueue == null)
                    throw new Exception("Printer error");
                // Get default printer settings
                //_printDialog.PrintTicket = _printDialog.PrintQueue.DefaultPrintTicket;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            PrintTicket = _printDialog.PrintTicket;
            TicketCapabilities = _printDialog.PrintQueue.GetPrintCapabilities(PrintTicket);
            PageSize = new Size((double)TicketCapabilities.OrientedPageMediaWidth,
                (double)TicketCapabilities.OrientedPageMediaHeight);
            SetPageMargins(PageMargins); // Update margins if too small
            return true;
        }
        /// <summary>
        ///  Start printing pages from paginator.
        /// </summary>
        public void Print(MyDocumentPaginator paginator, string printTaskDescription)
        {
            if (_printDialog == null)
                return;
            // Start printing document
            _printDialog.PrintDocument(paginator, printTaskDescription);
        }
        /// <summary>
        /// Set page margins and return true.
        /// <para/>
        /// If new page margins are too small (unprinted area) then set minimum and return false.
        /// </summary>
        public bool SetPageMargins(Thickness margins)
        {
            PageImageableArea pia = TicketCapabilities.PageImageableArea;
            PageMargins = new Thickness(Math.Max(margins.Left, pia.OriginWidth),
                Math.Max(margins.Top, pia.OriginHeight),
                Math.Max(margins.Right, PageSize.Width - pia.OriginWidth - pia.ExtentWidth),
                Math.Max(margins.Bottom, PageSize.Height - pia.OriginHeight - pia.ExtentHeight));
            return PageMargins == margins;
        }
        /// <summary>
        /// Set pate margins with minimal
        /// </summary>
        public void SetMinimalPageMargins()
        {
            PageImageableArea pia = TicketCapabilities.PageImageableArea;
            // Set minimal page margins to bypass the unprinted area.
            PageMargins = new Thickness(pia.OriginWidth, pia.OriginHeight,
                (double)TicketCapabilities.OrientedPageMediaWidth - - pia.OriginWidth - pia.ExtentWidth,
                (double)TicketCapabilities.OrientedPageMediaHeight - pia.OriginHeight - pia.ExtentHeight);
        }
        /// <summary>
        /// Create page control witch pageContent ready to print.
        /// Content is stretched to the margins.
        /// </summary>
        public FrameworkElement CreatePageWithContentStretched(FrameworkElement pageContent)
        {
            // Place the content inside the page (without margins)
            Viewbox pageInner = new Viewbox();
            pageInner.VerticalAlignment = VerticalAlignment.Top; // From the upper edge
            pageInner.Child = pageContent;
            // Printed control - the page with content
            Border whitePage = new Border();
            whitePage.Width = PageSize.Width;
            whitePage.Height = PageSize.Height;
            whitePage.Padding = PageMargins;
            whitePage.Child = pageInner;
            return whitePage;
        }
        /// <summary>
        /// Create page control witch pageContent ready to print.
        /// <para/>
        /// Content is aligned to the top-center and must have
        /// a fixed size (max PageSize-PageMargins).
        /// </summary>
        public FrameworkElement CreatePageWithContentSpecSize(FrameworkElement contentSpecSize)
        {
            // Place the content inside the page
            Decorator pageInner = new Decorator();
            pageInner.HorizontalAlignment = HorizontalAlignment.Center;
            pageInner.VerticalAlignment = VerticalAlignment.Top;
            pageInner.Child = contentSpecSize;
            // Printed control - the page with content
            Border whitePage = new Border();
            whitePage.Width = PageSize.Width;
            whitePage.Height = PageSize.Height;
            // We align to the top-center only, because padding will cut controls
            whitePage.Padding = new Thickness(0, PageMargins.Top, 0, 0);
            whitePage.Child = pageInner;
            return whitePage;
        }
        /// <summary>
        /// Create paginator for pages created by CreatePageWithContent().
        /// </summary>
        public MyDocumentPaginator CreatePaginator()
        {
            return new MyDocumentPaginator(PageSize);
        }
    }
