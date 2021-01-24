    public class PivotData
    {
    	public IReadOnlyList<PivotValues> Columns { get; set; }
    	public IReadOnlyList<PivotDataRow> Rows { get; set; }
    }
    
    public class PivotDataRow
    {
    	public PivotValues Data { get; set; }
    	public IReadOnlyList<PivotValues> Values { get; set; }
    }
