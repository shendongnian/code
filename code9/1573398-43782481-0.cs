    [assembly: ExportRenderer (typeof (TextCell), typeof (RightDetailSample.iOS.TextCellRenderer))]
    namespace RightDetailSample.iOS
    {
        public class TextCellRenderer : Xamarin.Forms.Platform.iOS.TextCellRenderer
        {
    
            public override UITableViewCell GetCell (Cell item, UITableViewCell reusableCell, UITableView tv)
            {
                var textCell = (TextCell)item;
    
                var fullName = item.GetType ().FullName;
                var cell = tv.DequeueReusableCell (fullName) as CellTableViewCell;
                if (cell == null) {
                    cell = new CellTableViewCell (UITableViewCellStyle.Value1, fullName);
                } else {
                    cell.Cell.PropertyChanged -= cell.HandlePropertyChanged;
                }
    
                cell.Cell = textCell;
                textCell.PropertyChanged += cell.HandlePropertyChanged;
                cell.PropertyChanged = this.HandlePropertyChanged;
    
                cell.TextLabel.Text = textCell.Text;
    
                cell.DetailTextLabel.Text = textCell.Detail;
    
    
                UpdateBackground (cell, item);
    
                return cell;
            }
        }
    }
