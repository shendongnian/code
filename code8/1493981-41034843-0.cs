    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Print Preview
        public void PrintPreview(FixedDocument fixeddocument, CancellationToken ct)
        {
            // Was cancellation already requested? 
            if (ct.IsCancellationRequested)
                ct.ThrowIfCancellationRequested();
            MemoryStream ms = new MemoryStream();
            using (Package p = Package.Open(ms, FileMode.Create, FileAccess.ReadWrite))
            {
                Uri u = new Uri("pack://TemporaryPackageUri.xps");
                PackageStore.AddPackage(u, p);
                XpsDocument doc = new XpsDocument(p, CompressionOption.Maximum, u.AbsoluteUri);
                XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);
                //writer.Write(fixeddocument.DocumentPaginator);
                Dispatcher.Invoke(new Action<DocumentPaginator>(writer.Write), fixeddocument.DocumentPaginator);
                FixedDocumentSequence fixedDocumentSequence = doc.GetFixedDocumentSequence();
                var previewWindow = new PrintPreview(fixedDocumentSequence);
                Action closeAction = () => previewWindow.Close();
                ct.Register(() =>
                      previewWindow.Dispatcher.Invoke(closeAction)
                );
                previewWindow.ShowDialog();
                PackageStore.RemovePackage(u);
                doc.Close();
            }
        }
    }
