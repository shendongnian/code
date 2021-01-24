    class MyDocumentViewer : DocumentViewer
    {
        internal void RemoveToolbarShadow()
        {
            r = this.FindType<System.Windows.Controls.Border>()?
                .FindType<Grid>()?
                .FindType<DockPanel>()?
                .FindType<System.Windows.Shapes.Rectangle>();
    
            if (null != r) r.Visibility = Visibility.Hidden;
        }
    }
