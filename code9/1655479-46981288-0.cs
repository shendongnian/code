        private void AddBoundDataGridViewComboBoxColumn(
            DataGridView dgv,
            string dataPropertyName,
            string displayMember,
            string valueMember,
            object dataSource,
            string headerText,
            string toolTipText = "")
        {
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            int columnIndex;
            if (ts.TraceVerbose) Trace.WriteLine("entering");
            try
            {
                #region	Try
                comboBoxColumn.DataPropertyName = dataPropertyName;
                comboBoxColumn.Name = dataPropertyName;
                comboBoxColumn.DisplayMember = displayMember;
                comboBoxColumn.ValueMember = valueMember;
                comboBoxColumn.DataSource = dataSource;
                columnIndex = dgv.Columns.Add(comboBoxColumn);
                dgv.Columns[columnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv.Columns[columnIndex].HeaderText = headerText;
                dgv.Columns[columnIndex].ToolTipText = toolTipText;
                if (ts.TraceVerbose) Trace.WriteLine("Column added to " + dgv.Name + ": " + dataPropertyName + " (Tool tip: " + toolTipText + ")");
                #endregion Try
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (ts.TraceVerbose) Trace.WriteLine("exiting");
            }
        }
