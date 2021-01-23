    public interface IEffective 
    {
         DateTime EffectiveFromTime {get; set;}
         DateTime EffectiveToTime {get; set;}
    }
    public partial AddNewOELEntryInvolvedEntitiesUnlinkedInvolvedAddressUnlinked
        : IEffective { }
    public partial AddNewOELEntryInvolvedEntitiesUnlinkedInvolvedPersonUnlinked
        : IEffective { }
