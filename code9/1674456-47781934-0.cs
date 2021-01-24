    public partial class MainWindow : Window
    {
        private PdfDocument document;
        private double lineHeight = 20;
        private XFont fontParagraph = new XFont("Verdana", 12, XFontStyle.Regular);
        private int marginLeft = 20;
        private int marginRight = 20;
        private int marginTop = 20;
        private int nameX = 0;
        private int quantityX = 100;
        private int unitX = 200;
        private string filename = @"C:\Users\Christian\Desktop\Orders.pdf";
        XSolidBrush TextBackgroundBrush = new XSolidBrush(XColors.LightGray);
        public MainWindow()
        {
            InitializeComponent();
            document = new PdfDocument();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var OrderList = new List<Order>();
            OrderList.Add(new Order {
                Unit = "L",
                Quantity = 100,
                Product = new Product { Name = "Coca Cola" }
            });
            OrderList.Add(new Order
            {
                Unit = "L",
                Quantity = 50,
                Product = new Product { Name = "Coca Cola Zero" }
            });
            PdfPage pdfPage = document.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            for (int i = 0; i < OrderList.Count; i++)
            {
                double lineY = lineHeight * (i + 1);
                if (i % 2 == 1)
                {
                    graph.DrawRectangle(TextBackgroundBrush, marginLeft, lineY - 2 + marginTop, pdfPage.Width - marginLeft - marginRight, lineHeight - 2);
                }
                graph.DrawString(
                    OrderList[i].Product.Name,
                    fontParagraph,
                    XBrushes.Black,
                    new XRect(nameX + marginLeft, marginTop + lineY, pdfPage.Width.Point, pdfPage.Height.Point),
                    XStringFormats.TopLeft);
                graph.DrawString(
                    OrderList[i].Quantity.ToString(),
                    fontParagraph,
                    XBrushes.Black,
                    new XRect(quantityX + marginLeft, marginTop + lineY, pdfPage.Width.Point, pdfPage.Height.Point),
                    XStringFormats.TopLeft);
                graph.DrawString(
                    OrderList[i].Unit,
                    fontParagraph,
                    XBrushes.Black,
                    new XRect(unitX + marginLeft, marginTop + lineY, pdfPage.Width.Point, pdfPage.Height.Point),
                    XStringFormats.TopLeft);
            }
            document.Save(filename);
            Process.Start(filename);
        }
        private class Order
        {
            public int Quantity { get; set; }
            public string Unit { get; set; }
            public Product Product { get; set; }
        }
        private class Product
        {
            public string Name { get; set; }
        }
    }
