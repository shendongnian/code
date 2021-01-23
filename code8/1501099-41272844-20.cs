    public enum LeadStatus : byte
    {
        [Display(Name = "Created"), ExtrasDisplay(BackgroundColor = "Red")]Created = 1,
        [Display(Name = "Assigned")] Assigned = 2,
    }
