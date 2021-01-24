        public MainWindow()
        {
            InitializeComponent();
            RichTextBox rtb = new RichTextBox();
            rtb.Language = System.Windows.Markup.XmlLanguage.GetLanguage("fa-IR");
            rtb.Document.Blocks.Add(new Paragraph(new Run("درست")) { FlowDirection = FlowDirection.RightToLeft });
            TextRange tr = new TextRange(rtb.Document.ContentStart,
                                rtb.Document.ContentEnd);
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                tr.Save(ms, DataFormats.Rtf);
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                System.IO.File.WriteAllBytes(@"J:\test.rtf", ms.ToArray());
            }
        }
