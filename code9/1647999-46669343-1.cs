    public class GenericRepo<TEntity> where TEntity : EntityBase
    {
        ...
        public void UpdateByStringColumn(string lookupCol, string col1Value, string col2Value)
        {
            //if you want it to break in case no entity was found, change it to First and remove the santity check
            var entity = this.DbSet.FirstOrDefault(p => p.LookupCol == lookupCol); 
            if (entity != null) 
            {
                entity.Col1 = col1Value;
                entity.Col2 = col2Value;
                Context.SaveChanges();
            }
    }
}
