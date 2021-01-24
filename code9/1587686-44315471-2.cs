    private void Server_RaiseAlert(object sender, EventArgs e)
    {
        var context = new ApplicationDbContext();
        var alerts = context.Alerts.Where(x => x.IsResolved == false).ToList();
        if (alerts.Count > 0)
        {
            spFoo.Dispatcher.Invoke(new Action(() =>
            {
                foreach (var alert in alerts)
                {
                    var button = (Button)spFoo.Children[FooId];
                    button.Style = FindResource("FooAlertIcon") as Style;
                }
            }));
        }
    }
