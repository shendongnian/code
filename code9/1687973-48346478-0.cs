    ListViewItem lvi = ticketListview.ContainerFromItem(item) as ListViewItem;
                while(lvi == null)
                {
                    await Task.Delay(25);
                    lvi = ticketListview.ContainerFromItem(item) as ListViewItem;
                }
