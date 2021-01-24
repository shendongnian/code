        private static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null)
                return null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null)
                    return result;
            }
            return null;
        }
        private void DGrdDatosImportar_Drop(object sender, DragEventArgs e)
        {
            ScrollViewer sv = GetChildOfType<ScrollViewer>(DGrdDatosImportar);
            if (sv != null)
            {
                double horizontalOffset = sv.HorizontalOffset;
                var dropPos = e.GetPosition(DGrdDatosImportar);
                double relativeXPos = dropPos.X + horizontalOffset;
                double RefPos = DGrdDatosImportar.RowHeaderActualWidth;
                DataGridColumn SelecteCol = null;
                foreach (DataGridColumn Col in DGrdDatosImportar.Columns.ToList())
                {
                    double ColWidth = Col.ActualWidth;
                    if (relativeXPos >= RefPos && relativeXPos <= (RefPos + ColWidth))
                    {
                        SelecteCol = Col;
                        break;
                    }
                    RefPos += ColWidth;
                }
                if (SelecteCol != null)
                {
                    if (e.Data.GetDataPresent("IImportProperty"))
                    {
                       ...
                    }
                }
            }
        }
