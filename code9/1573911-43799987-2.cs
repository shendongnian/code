    public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
    {
        var cell = base.GetCell(item, reusableCell, tv);        
        cell.ContentView.BackgroundColor = UIColor.Red;
        return cell;
    }
