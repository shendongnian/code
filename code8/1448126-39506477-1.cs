    public partial class SplitControlCustom : SplitContainer
        {
            public SplitControlCustom()
            {
                InitializeComponent();
            }
    
            public void ForceDrageDrop(DragEventArgs eventArgs)
            {
                OnDragDrop(eventArgs);
            }
    
            public void ForceDragEnter(DragEventArgs eventArgs)
            {
                OnDragEnter(eventArgs);
            }
        }
