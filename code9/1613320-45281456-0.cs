    public class ExtendedCell : DataGridViewTextBoxCell 
    {
       public ExtendedCell(): base()
       {
       }
    public override object DefaultNewRowValue
    {
        get
        {
            return "aaa";
        }
    }
    ExtendedColumn col = new ExtendedColumn();
    col.Name = AttendanceType;
    dgv1.Columns.Add(col);
