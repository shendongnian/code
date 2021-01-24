    public class MyCustomColumn : DataGridViewColumn
    {
       public MyCustomColumn()
       {
          this.CellTemplate = new MyCustomCell();
          //Set the .ValueType of its Cells to Bitmap
          this.CellTemplate.ValueType = typeof(System.Drawing.Bitmap);
       }
    }
