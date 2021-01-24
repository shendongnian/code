    public class Parameters
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int Frequency { get; set; }
        public int Conserve { get; set; }
    }
    ...
    // TODO: Hacky solution
    pm = await ps.GetParams(); // call to webservice
    pm.Id = 1;
    await con.InsertOrReplaceAsync(pm);
    ...
