    public interface IRepo
    {
        [Recordset(1, typeof(RuleDetail), into="Source", IsChild=true)]
        [Recordset(2, typeof(RuleDetail), into="Destination", IsChild=true)] 
        Rule GetFullyPopulatedRuleByIdStoredProcedure(int id);
    }
