    public class MyCustomCell : DataGridViewImageCell
    {
       public MyCustomCell()
          : this(true) { }
          
       public MyCustomCell(bool valueIsIcon)
       {
          //Set the .ImageLayout to "Zoom", so the image will scale
          this.ImageLayout = DataGridViewImageCellLayout.Zoom;
          //This is the pre-defined image if no image is set as Value. You can set this to whaterver you want.
          //Here I'm defining an invisible bitmap of 1x1 pixels
          this.Value = new System.Drawing.Bitmap(1,1);
          //This is an internal switch. Doesn't mean much here. Set to true to comply with the standard.
          this.ValueIsIcon = valueIsIcon;
       }
          
       public override DataGridViewAdvancedBorderStyle AdjustCellBorderStyle(
             DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStyleInput,
             DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStylePlaceHolder,
             bool singleVerticalBorderAdded,
             bool singleHorizontalBorderAdded,
             bool firstVisibleColumn,
             bool firstVisibleRow)
       {
          //Set the new values for these cells borders, leaving out the right one.
          dataGridViewAdvancedBorderStylePlaceHolder.Right = DataGridViewAdvancedCellBorderStyle.None;
    
          dataGridViewAdvancedBorderStyleInput.Top = DataGridViewAdvancedCellBorderStyle.Single;
          dataGridViewAdvancedBorderStylePlaceHolder.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
          dataGridViewAdvancedBorderStyleInput.Left = DataGridViewAdvancedCellBorderStyle.Single;
    
          return dataGridViewAdvancedBorderStylePlaceHolder;
       }
    }
