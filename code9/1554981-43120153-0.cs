    var items = pSelectedItem.Nodes
                .Expand(e => e.Nodes)
                .Where(e => e.Nodes == null && e.Tag is List<ActionObject>)
                .Select(e => (List<ActionObject>)e.Tag)
                .SelectMany(aclist => aclist.Where(ac => ac != null))
                .Select(i => new ListViewItem()
                {
                    Tag = new ListViewValue[]
                    {
                        new ListViewValue() { Value = i.Command },
                        new ListViewValue() { Value = i.Target },
                        new ListViewValue() { Value = i.Value },
                        new ListViewValue() { Value = i.Comment }
                    }
                };
