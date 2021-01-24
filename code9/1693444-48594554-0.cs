     private void dgvResults_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var selectedColumn = this.dgvResults.Columns[e.ColumnIndex];
            var vm = (PurchaseOrdersTrackingViewModel) this.dgvResults.Rows[e.RowIndex].DataBoundItem;
            if (selectedColumn.Name == this.colDueDate.Name)
            {
                this.SingleDueDate = Convert.ToDateTime(this.dgvResults.Rows[e.RowIndex].Cells[this.colDueDate.Index].Value);
                if (!this._mapicsWorkday.IsWorkDay(this.SingleDueDate.Date))
                {
                    this.ShowMessage("Due date selected must be a valid working day.");
                    return;
                }
                if (this.SingleDueDate.Date < DateTime.Today)
                {
                    this.ShowMessage("You cannot set a past date as a due date.");
                    return;
                }
                vm.HasCommentUpdateApplied = true;
                this.UpdateSingleOrder = true;
                this._presenter.BulkUpdateItems();
            }
        }
