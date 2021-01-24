    public class GuestItem
    {
        public int Id { get; set; }
    
        public int GuestDefinitionId { get; set; }
        public virtual GuestDefinition GuestDefinition { get; set; }
    
        public virtual Invitation Invitation { get; set; }
    }
    
    public class Invitation
    {
        [Key, ForeignKey("GuestItem ")]
        public int GuestItemId { get; set; }
        public virtual GuestItem GuestItem { get; set; }
    }
