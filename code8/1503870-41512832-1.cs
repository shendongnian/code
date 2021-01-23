    protected Rectangle CalculateCellEditorBoundsStandard(OLVListItem item, int subItemIndex, Rectangle cellBounds, Size preferredSize) {
                if (this.View == View.Tile)
                    return cellBounds;
    
                // Center the editor vertically
                if (cellBounds.Height != preferredSize.Height)
                    cellBounds.Y += (cellBounds.Height - preferredSize.Height) / 2;
    
                // Only Details view needs more processing
                if (this.View != View.Details) 
                    return cellBounds;
    
                // Allow for image (if there is one). 
                int offset = 0;
                object imageSelector = null;
                if (subItemIndex == 0)
                    imageSelector = item.ImageSelector;
                else {
                    // We only check for subitem images if we are owner drawn or showing subitem images
                    if (this.OwnerDraw || this.ShowImagesOnSubItems)
                        imageSelector = item.GetSubItem(subItemIndex).ImageSelector;
                }
                if (this.GetActualImageIndex(imageSelector) != -1) {
                    offset += this.SmallImageSize.Width + 2;
                }
    
                // Allow for checkbox
                if (this.CheckBoxes && this.StateImageList != null && subItemIndex == 0) {
                    offset += this.StateImageList.ImageSize.Width + 2;
                }
    
                // Allow for indent (first column only)
                if (subItemIndex == 0 && item.IndentCount > 0) {
                    offset += (this.SmallImageSize.Width * item.IndentCount);
                }
    
                // Do the adjustment
                if (offset > 0) {
                    cellBounds.X += offset;
                    cellBounds.Width -= offset;
                }
    
                return cellBounds;
            }
