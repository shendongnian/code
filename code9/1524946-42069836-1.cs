        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data is Category && dropInfo.TargetItem is Rubrique)
            {
                return;
            }
            dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
            dropInfo.Effects = DragDropEffects.Move;
        }
