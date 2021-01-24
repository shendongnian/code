    public sealed class SPMap : ClassMap<AdvanceSearchSP_Result>
    {
        public SPMap()
        {
            Map(m => m.SERVICETAG).Name("Service Tag").Index(0);
            Map(m => m.sitename).Name("Site Name").Index(1);
            /*repeat for other properties */
            ..
            .. 
        }
    }
