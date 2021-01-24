    public static List<new_placement>ActivityCounter(Account account, CRM2011DataContext CRMcontext)
    {
    var myActivities = (from a in CRMcontext.new_placementSet
                             where
                             a.new_entity_identifier.Value != 6
                             a.new_entity_identifier.Value != 7
                             a.new_entity_identifier.Value != 8
                             a.new_entity_identifier.Value != 9 // And so on..
                                 select new new_placement() { ActivityId = a.ActivityId }).ToList();
        return myActivities;
    }
