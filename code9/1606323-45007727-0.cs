    //you might want to implement INotifyPropertyChanged for viewmodel classes. 
    //i did not do so in this example.
    public class MainPanelViewmodel 
    {
       public TrendModel PlotModel { get; set; }
       public Histogram HistogramModel { get; set; }
    }
