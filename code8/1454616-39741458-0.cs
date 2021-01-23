    bool dataChangingInCode = false;
        public void InitializeCustomCode()
        {
            JobPart_Column.ColumnChanged += JobPart_ColumnChanged;
        }
        private void JobPart_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (dataChangingInCode) return;
            switch (e.Column.ColumnName)
            {
                case "BI_JobDetailerID_c":
                    dataChangingInCode = true;
                    e.Row["BI_JobOutsourceID_c"] = string.Empty;
                    dataChangingInCode = false;
                    break;
                case "BI_JobOutsourceID_c":
                    dataChangingInCode = true;
                    e.Row["BI_JobDetailerID_c"] = string.Empty;
                    dataChangingInCode = false;
                    break;
            }
        }
