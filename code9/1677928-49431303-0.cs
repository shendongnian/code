    public class NHLogger : EmptyInterceptor, IInterceptor
    {
        public override NHibernate.SqlCommand.SqlString 
           OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            System.Diagnostics.Debug.WriteLine("NHIBERNATE: " +  sql);
            return base.OnPrepareStatement(sql);
        }
    }
