        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            var wordDocument = Application.Documents.Add(System.Type.Missing);
            var shape = wordDocument.Shapes.AddShape(1, 10, 10, 30, 30);
        }
