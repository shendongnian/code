    ListView listView = new ListView {
        SeparatorColor = Color.Green,
        ItemsSource    = ListlvData
    };
    listView.ItemTemplate = new DataTemplate(() => {
        ViewCell cell = new ViewCell();
        cell.Tapped += (sender, args) => {
            cell.View.BackgroundColor = Color.Red;
            OnListViewTextCellTapped(cell);            //Run your actual `Tapped` event code
            cell.View.BackgroundColor = Color.Default; //Turn it back to the default color after your event code is done
        };
        cell.View = new Image();
        return cell;
    });
