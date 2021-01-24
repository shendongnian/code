            FixedDocument fixedDocument = new FixedDocument();
            DocumentViewer dv = new DocumentViewer() { Document = fixedDocument };
            this.Content = dv;
            var page1 = new FixedPage() { Width = 600, Height = 800 };
            PageContent page1Content = new PageContent() { Child = page1 };
            var sp = new StackPanel();
            sp.Children.Add(new TextBlock
            {
                Text = "Title",
                FontSize = 30,
                Margin = new Thickness(100, 50, 0, 70)
            }); 
            sp.Children.Add(new TextBlock
            {
                Text = "The quick brown fox jumps over the lazy dog...",
                FontSize = 15,
                Margin = new Thickness(10, 0, 0, 10)
            }); 
            Rectangle rect = new Rectangle();
            rect.Width = 150;
            rect.Height = 150; 
            rect.Fill = Brushes.Black;
            sp.Children.Add(new Rectangle
            {
                Width = 150,
                Height = 150,
                Fill = Brushes.Black
            }); 
            page1.Children.Add(sp);
            fixedDocument.Pages.Add(page1Content);
