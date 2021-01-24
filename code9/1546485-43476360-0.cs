    public static T GetSelectedPOCO<T>(this DataGridView grid) where T : class
    {
        return (grid.SelectedRows.Count == 1)
            ? grid.SelectedRows[0].DataBoundItem as T
            : null;
    }
