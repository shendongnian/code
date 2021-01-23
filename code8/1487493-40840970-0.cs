           private static StreamReader streamToPrint;
        static void Main(string[] args)
        {
            string printFormat;
            printFormat = "txt";
            try
            {
                streamToPrint = new StreamReader(@"D:\TestText.txt");
                PrintDocument printDoc = new PrintDocument
                {
                    PrinterSettings = new PrinterSettings
                    {
                        PrinterName = "Microsoft Print to PDF",
                        PrintToFile = true,
                        PrintFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/test.pdf"
                    }
                };
                printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 210, 290);
                printDoc.PrinterSettings.DefaultPageSettings.Landscape = false;
                printDoc.PrinterSettings.DefaultPageSettings.Margins.Top = 0;
                printDoc.PrinterSettings.DefaultPageSettings.Margins.Left = 0;
                switch (printFormat)
                {
                    case "jpg":
                        printDoc.PrintPage += printDoc_PrintImage;
                        break;
                    case "txt":
                        printDoc.PrintPage += printDoc_PrintText;
                        break;
                    default:
                        break;
                }
                printDoc.Print();
            }
            finally
            {
                streamToPrint.Close();
            }
            Console.ReadKey(true);
        }
        static void printDoc_PrintImage(object sender, PrintPageEventArgs e)
        {
            Image photo = Image.FromFile(@"D:\TestImage.jpg");
            Point pPoint = new Point(0, 0);
            e.Graphics.DrawImage(photo, pPoint);
        }
        static void printDoc_PrintText(object sender, PrintPageEventArgs e)
        {
            Font printFont;
            printFont = new Font("Arial", 10);
            float linesPerPage = 0;
            // Calculate the number of lines per page.
            linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
            float yPos = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            while (count < linesPerPage &&
          ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count *
                   printFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }
            // If more lines exist, print another page.
            if (line != null)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }
