    using System;
    using System.Drawing.Printing;
    using System.Windows;
    
    namespace _09_Printers
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
    
            public MainWindow()
            {
                InitializeComponent();
    
                GetPrinterNamesAndPaperSize();
            }
            
            public void GetPrinterNamesAndPaperSize()
            {
                var printDoc = new PrintDocument();
    
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    Console.WriteLine(printer);
                    Console.WriteLine("**************************");
    
                    printDoc.PrinterSettings.PrinterName = printer;
    
                    foreach (PaperSize paperSize in printDoc.PrinterSettings.PaperSizes)
                    {
                        Console.WriteLine($"PaperName:{paperSize.PaperName}, PaperSize: {paperSize.Height},{paperSize.Width}");
                    }
                }
            }
        }
    }
    
