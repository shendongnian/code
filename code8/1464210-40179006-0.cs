    public interface IRepo
    {
        [Recordset(1, typeof(Source), IsChild=true)]
        [Recordset(2, typeof(Destination), IsChild=true)] 
        Rule GetFullyPopulatedRuleByIdStoredProcedure(int id);
    }
