    public class BudgetEntryNotesVM
    {
        public string AccountNumber { get; set; }
        public string AccountDescription { get; set; }
        public IEnumerable<BudgetNoteLineEntryVM> BudgetNoteLineEntryList { get; set; }
        public IEnumerable<BudgetNoteLineEntryColumnsVM> BudgetNoteLineEntryColumnsList { get; set; }
        public string[,] BudgetLineEntryArray { get; set; }
    }
