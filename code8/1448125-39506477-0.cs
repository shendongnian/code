    public partial class RichTextBoxCustom : RichTextBox
    {
        public RichTextBoxCustom()
        {
            InitializeComponent();
            this.AllowDrop = true;
            
        }
        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            base.OnDragEnter(drgevent);
        }
        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            MessageBox.Show("Hello");
            base.OnDragDrop(drgevent);
        }
    }
