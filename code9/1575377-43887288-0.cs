    GridTextColumn customerImageColumn = new GridTextColumn();
    customerImageColumn.UserCellType = typeof(GridImageCell);
    customerImageColumn.MappingName = "CustomerImage";
    customerImageColumn.HeaderText = "Image";
    
    //GridImageCell.cs
    public class GridImageCell : GridCell
        {
            private UIImageView imageview;
            CoreGraphics.CGRect framespec = new CoreGraphics.CGRect();
    
            public GridImageCell()
            {
                imageview = new UIImageView();
                this.CanRenderUnLoad = false;
            }
    
            protected override void UnLoad()
            {
                this.RemoveFromSuperview();
            }
           
            public override void LayoutSubviews()
            {
                base.LayoutSubviews();
                if (imageview.Superview == null)
                {
                    this.AddSubview(imageview);
                    framespec = new CoreGraphics.CGRect(20, 3, 60, (nfloat)DataColumn.Renderer.DataGrid.RowHeight - 5);
                }
                
                imageview.Frame = framespec;
                imageview.Image = (UIImage)DataColumn.RowData.GetType().GetProperty("CustomerImage").GetValue(DataColumn.RowData);
            }
    }
