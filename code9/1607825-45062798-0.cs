     public override UITableViewCell GetCell(Cell item, UITableView tv)
      {
        var cell = base.GetCell(item, tv);
         cell.SelectedBackgroundView = new UIView {
         BackgroundColor = UIColor.DarkGray,
       };
      return cell;
     }
