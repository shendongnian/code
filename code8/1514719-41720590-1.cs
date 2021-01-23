        public MyFormView()
        {
            ...
            InitColumnHeaders();
        }
        private void InitColumnHeaders()
        {
            foreach (GridViewDataColumn column  in gvMyGrid.Columns)
            {
                if (column.Name.Contains("_Current"))
                {
                    column.HeaderText += "\r\n" + DateTime.Now.Year.ToString();
                }
                else if (column.Name.Contains("_Prior"))
                {
                    column.HeaderText += "\r\n" + (DateTime.Now.Year - 1).ToString();
                }
            }
        }
