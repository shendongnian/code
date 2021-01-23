            private void dg_TimeTable_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            int rowIndex = dg_TimeTable.SelectedIndex;
            if (e.Column == colTeacherList)
            {
                FrameworkElement element = e.EditingElement;
                ComboBox cb = GetVisualChild<ComboBox>(element);
                if (cb != null)
                {
                    switch(dg_TimeTable.SelectedIndex)
                    {
                        case 1:
                            cb.ItemsSource = listTeachersSeven;
                            break;
                        case 2:
                            cb.ItemsSource = listTeachersEight;
                            break;
                        default:
                            cb.ItemsSource = listTeachersSix;
                            break;
                    }                        
                }
            }
        }
        static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
