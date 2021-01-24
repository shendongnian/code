    public class EmployeeToJobTitleMatchLinkMap : ClassMap<EmployeeToJobTitleMatchLinkNHEntity>
    {
    
        public EmployeeToJobTitleMatchLinkMap()
        {
    
            Schema("dbo");
            Table("EmployeeToJobTitleMatchLink");
    
            Id(x => x.LinkSurrogateUUID).GeneratedBy.GuidComb();
            Map(x => x.PriorityRank);
            Map(x => x.JobStartedOnDate);
    
            References(x => x.TheEmployee).Column("TheEmployeeUUID").Not.Nullable().Index("IX_ETJTMLM_TheEmployeeUUID_And_TheJobTitleUUID"); ;/*Bad naming convention with "The", but left here so it can be seen easily in the DDL*/
            References(x => x.TheJobTitle).Column("TheJobTitleUUID").Not.Nullable().Index("IX_ETJTMLM_TheEmployeeUUID_And_TheJobTitleUUID"); ;/*Bad naming convention with "The", but left here so it can be seen easily in the DDL*/
    
        }
    }
