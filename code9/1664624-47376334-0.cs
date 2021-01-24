    foreach (ListViewItem LVItem in TeamLstVw.Items)
    {
        var Team = (Team)LVItem.Tag;
        //I'd personally compare an identifier here. Like an Id property
        //.Any(x => x.Id == Team.Id)
        //Or use .Contains(): value.Teams.Contains(Team)
        if(value.Teams.Any(x => x == Team)) {
            LVItem.Selected = true;
        }
    }
