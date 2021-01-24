        private void GridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e) {
            GridView view = sender as GridView;
            if (view == null)
                return;
            if (e.Column.FieldName == "Answer" && view.IsValidRowHandle(e.RowHandle)) {
                string question = (sender as GridView).GetRowCellValue(e.RowHandle, "Question").ToString();
                RepositoryItemRadioGroup item = null;
                repositories.TryGetValue(question, out item);
                if (item != null)
                    e.RepositoryItem = item;
            }
        }
