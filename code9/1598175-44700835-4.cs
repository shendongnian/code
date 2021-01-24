    namespace CheckListBoxFromSQL_Server
    {
        public class CheckListBoxItem
        {
            /// <summary>
            /// Identifier for database table
            /// </summary>
            public int PrimaryKey;
            /// <summary>
            /// Display member for CheckedListBox and a field in the table
            /// </summary>
            public string Description;
            public int Quantity;
            /// <summary>
            /// Indicates the checked state in the database table and for setting a Checked item in the CheckedListbox
            /// </summary>
            public bool Checked;
            /// <summary>
            /// Used to determine if a item changed after loaded in the CheckedListBox
            /// </summary>
            public bool IsDirty;
            public override string ToString() { return Description; }
        }
    }
