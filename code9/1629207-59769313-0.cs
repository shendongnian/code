    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    namespace Fatele.Imp.Exp.Application.Applications.Components {
        public class DataGridBehaviour {
          public static readonly DependencyProperty NavLikeProperty = DependencyProperty.RegisterAttached("NavLike",
                typeof(bool), typeof(DataGridBehaviour), new UIPropertyMetadata(NavLikeChanged));
            public static bool GetNavLike(DependencyObject obj) {
                return (bool) obj.GetValue(NavLikeProperty);
            }
            public static void SetNavLike(DependencyObject obj, bool value) {
                obj.SetValue(NavLikeProperty, value);
            }
            private static void NavLikeChanged(object oo, DependencyPropertyChangedEventArgs ee) {
                var odg = (DataGrid) oo;
                odg.KeyUp += KeyUp;
            }
            private static void KeyUp(object sender, KeyEventArgs e) {
                var dataGrid = sender as DataGrid;
                if (dataGrid == null) {
                    return;
                }
                if (e.Key != Key.LeftCtrl) {
                    return;
                }
                if (dataGrid.SelectedCells.Count < 2) {
                    return;
                }
                var firstCell = dataGrid.SelectedCells.First();
                var propertyInfo = firstCell.Item.GetType().GetProperty(firstCell.Column.SortMemberPath);
                if (propertyInfo == null) {
                    return;
                }
                var value1 = propertyInfo.GetValue(firstCell.Item);
                foreach (var cellInfo in dataGrid.SelectedCells.Skip(1)) {
                    var value2 = propertyInfo.GetValue(cellInfo.Item);
                    if (value2 == null) {
                        propertyInfo.SetValue(cellInfo.Item, value1);
                    }
                }
            }
        }
    }
