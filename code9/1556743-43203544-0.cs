    private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case CollectionChangeAction.Add:
                var addedRow = (SomeClass)gridView1.GetRow(e.ControllerRow);
                if (!_selected.Contains(addedRow)) //You need this check only when gridView1.OptionsSelection.MultiSelectMode == GridMultiSelectMode.CellSelect
                    _selected.Add(addedRow);
                break;
            case CollectionChangeAction.Remove:
                _selected.Remove((SomeClass)gridView1.GetRow(e.ControllerRow));
                break;
            case CollectionChangeAction.Refresh:
                gridView2.BeginDataUpdate();
                _selected.Clear();
                var rows = gridView1.GetSelectedRows().Select(row => (SomeClass)gridView1.GetRow(row));
                foreach (var row in rows)
                    _selected.Add(row);
                gridView2.EndDataUpdate();
                break;
        }
    }
