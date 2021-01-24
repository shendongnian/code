    using System.Collections.ObjectModel;
    namespace DataGridTry
    {
        public class ThingBeingPublished
        {
            public DateTime PublishDate { get; set; }
        };
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                var listOfThings = new ObservableCollection<ThingBeingPublished();
                listOfThings.Add(new ThingBeingPublished() { PublishDate = DateTime.Now.AddDays(-2) });
                listOfThings.Add(new ThingBeingPublished() { PublishDate = DateTime.Now.AddDays(-1) });
                listOfThings.Add(new ThingBeingPublished() { PublishDate = DateTime.Now });
                DG1.ItemsSource = listOfThings;
            }
        }
    }
