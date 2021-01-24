    void GridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e) {
        GridView view = sender as GridView;
        if (e.Column.FieldName == "Answer" && view.IsValidRowHandle(e.RowHandle)) {
            string question = (string)view.GetRowCellValue(e.RowHandle, "Question");
            RepositoryItemRadioGroup item;
            if(repositories.TryGetValue(question, out item))
                e.RepositoryItem = item;
        }
    }
