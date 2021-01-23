    public class ChecklistFilled
    {
        ...
        public virtual ICollection<ItemsFilled> ItemsFilled { get; set; }
    }
    public class ItemsFilled
    {
        ...
        public int CheckListFilledId { get; set; }
        [ForeignKey("CheckListFilledId")]
        public virtual ChecklistFilled ChecklistFilled { get; set; }
    }
