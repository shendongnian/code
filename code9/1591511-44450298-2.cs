    public interface Iissue_id
    {
        int issue_id { get; set; }
    }
    
    public class table_a : Iissue_id
    {
        public int issue_id { get; set; }
        //other properties
    }
        
    public void DeleteAllRowsWithIssue_id(int issue_id)
    {
        using (var context = new MyContext())
        {
            foreach (var table in typeof(MyContext).Assembly.GetTypes().Where(x => x.GetInterface(nameof(Iissue_id)) != null).ToList())            
                context.Database.ExecuteSqlCommand($"delete from {table.Name} where id = @p0", issue_id);
        }
    }
