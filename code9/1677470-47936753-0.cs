    string sfp = "";
    private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
    {
        var activity = await result as Activity;
    
        // calculate something for us to return
        int length = (activity.Text ?? string.Empty).Length;
        sfp = System.Web.HttpContext.Current.Server.MapPath($"~/IMG/chart.png");
    
        Thread STAThread = new Thread(() =>
        {
            var myChart = new LiveCharts.Wpf.CartesianChart
            {
                DisableAnimations = true,
                Width = 600,
                Height = 200,
                Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Values = new ChartValues<double> {1, 6, 7, 2, 9, 3, 6, 5}
                    }
                }
            };
    
            var viewbox = new System.Windows.Controls.Viewbox();
            viewbox.Child = myChart;
            viewbox.Measure(myChart.RenderSize);
            viewbox.Arrange(new System.Windows.Rect(new Point(0, 0), myChart.RenderSize));
            myChart.Update(true, true); //force chart redraw
            viewbox.UpdateLayout();
    
            SaveToPng(myChart, "chart.png");
        });
    
        STAThread.SetApartmentState(ApartmentState.STA);
    
        STAThread.Start();
    
        STAThread.Join();
    
        await context.PostAsync($"You sent {activity.Text} which was {length} characters1");
    
        context.Wait(MessageReceivedAsync);
    }
