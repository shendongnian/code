    public void SetUpCell(string ParticipantName)
            {
                ParticipantNameLabel.Text = ParticipantName;
            }
    public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell("PeopleCell", indexPath) as PeopleCell;
    
                if (cell == null)
                {
                    cell = new PeopleCell(new NSString("PeopleCell"));
                }
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
                cell.SetUpCell(ListPeople[indexPath.Row]);
    
                return cell;
            }
