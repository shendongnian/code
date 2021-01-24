        public RichTbxFlowDocumentTest()
        {
            InitializeComponent();
            // Create a new FlowDocument, and add 3 paragraphs.
            FlowDocument flowDoc = new FlowDocument();
            flowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 1")));
            flowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 2")));
            flowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 3")));
            // Set the FlowDocument to be the content for a new RichTextBox.
            RichTextBox rtb = new RichTextBox(flowDoc);
            //Add RichTextBox and Button with setting cusor method to a new StackPanel
            StackPanel s = new StackPanel();
            Button button = new Button() { Content = "Set Cursor Pos" };
            button.Click += (sender, e) =>
            {
                //SET FOCUS
                rtb.Focus();
                // Get the current caret position.
                TextPointer caretPos = rtb.CaretPosition;
                //Set amount of position
                int displacement = 6;
                // Set the TextPointer 6 displacement backward
                caretPos = caretPos.GetPositionAtOffset(displacement, LogicalDirection.Backward);
                // Specify the new caret position to RichTextBox
                rtb.CaretPosition = caretPos;
            };
            s.Children.Add(button);
            s.Children.Add(rtb);
            this.Content = s;
        }
    }
