        using System.Windows.Documents;
        public async void SendToPrinter()
        {
            if (ImageSource == null || Image == null)
                return;
            var printDialog = new PrintDialog();
            bool? result = printDialog.ShowDialog();
            if (!result.Value)
                return;
            FixedDocument doc = GenerateFixedDocument(ImageSource, printDialog);
            printDialog.PrintDocument(doc.DocumentPaginator, "");
        }
        private FixedDocument GenerateFixedDocument(ImageSource imageSource, PrintDialog dialog)
        {
            var fixedPage = new FixedPage();
            var pageContent = new PageContent();
            var document = new FixedDocument();
            bool landscape = imageSource.Width > imageSource.Height;
            if (landscape)
            {
                fixedPage.Height = dialog.PrintableAreaWidth;
                fixedPage.Width = dialog.PrintableAreaHeight;
                dialog.PrintTicket.PageOrientation = PageOrientation.Landscape;
            }
            else
            {
                fixedPage.Height = dialog.PrintableAreaHeight;
                fixedPage.Width = dialog.PrintableAreaWidth;
                dialog.PrintTicket.PageOrientation = PageOrientation.Portrait;
            }
            var imageControl = new System.Windows.Controls.Image {Source = ImageSource,};
            imageControl.Width = fixedPage.Width;
            imageControl.Height = fixedPage.Height;
            pageContent.Width = fixedPage.Width;
            pageContent.Height = fixedPage.Height;
            document.Pages.Add(pageContent);
            pageContent.Child = fixedPage;
            // You'd have to do something different here: possibly just add your 
            // tab to the fixedPage.Children collection instead.
            fixedPage.Children.Add(imageControl);
            return document;
        }
