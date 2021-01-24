    enum EntryType { Value, Description, NestedStats }
    class Entry
    {
        ...
        public EntryType EntryType
        {
            get
            {
                if (NestedStats != null) return EntryType.NestedStats;
                if (Description != null) return EntryType.Description;
                return EntryType.Value;
            }
        }
    }
