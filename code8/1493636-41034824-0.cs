    private int GetRowCountRecursive(GridView view, int rowHandle)
    {
        int totalCount = 0;
        int childrenCount = view.GetChildRowCount(rowHandle);
        for (int i = 0; i < childrenCount; i++)
        {
            var childRowHandle = view.GetChildRowHandle(rowHandle, i);
            if (view.IsGroupRow(childRowHandle))
            {
                totalCount += GetRowCountRecursive(view, childRowHandle);
            }
            else
            {
                totalCount++;
            }
        }
        return totalCount;
    }
