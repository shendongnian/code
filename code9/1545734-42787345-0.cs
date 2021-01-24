    int colIndex = 1;
    foreach (System.ComponentModel.PropertyDescriptor descriptor in System.ComponentModel.TypeDescriptor.GetProperties(list))
    {
        workSheet.Cells[1, colIndex++] = descriptor.Name;
    }
