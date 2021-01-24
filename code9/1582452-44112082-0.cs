    var stuffToRemove = exposur.SingleOrDefault( s => s.Campaigns.ID == Camp.Campaign.ID )
    if( stuffToRemove.ID != 0 )
    {
        exposur.Remove( stuffToRemove );
    }
