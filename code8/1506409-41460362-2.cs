    public class SomeWindow : Window
    {
        public SomeWindow()
        {
            rtbLog.Document = new FlowDocument(Logs.Paragraph);
        }
    }
