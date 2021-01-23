    public partial class RichTextBoxCustom : RichTextBox
    {
        public RichTextBoxCustom()
        {
            InitializeComponent();
            this.AllowDrop = true;
        }
        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            SplitControlCustom parentSplitControl = Parent.Parent as SplitControlCustom;
            if (parentSplitControl != null)
            {
                parentSplitControl.ForceDragEnter(drgevent);
            }
        }
        protected override void OnDragDrop(DragEventArgs drgevent)
        {
    
            SplitControlCustom parentSplitControl = Parent.Parent as SplitControlCustom;
            if (parentSplitControl != null)
            {
                parentSplitControl.ForceDrageDrop(drgevent);
            }
        }
    }
