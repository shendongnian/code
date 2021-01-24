        public DataGridColumnSettings(string Header, int ColumnIndex, bool IsReadOnly = true, string Width = "100", bool ComboBoxColumn = false, bool CheckBoxColumn = false)
        {
            this.Header = Header;
            this.ColumnIndex = ColumnIndex;
            this.IsReadOnly = IsReadOnly;
            this.Width = Width;
            this.ComboBoxColumn = ComboBoxColumn;
            this.CheckBoxColumn = CheckBoxColumn;
        }
