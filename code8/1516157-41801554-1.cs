    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Job> Jobs;
    
        public MainPage()
        {
            this.InitializeComponent();
            Jobs = new ObservableCollection<Job>();
        }
    
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string newJson = @"
            [
                {'job_id':399783,'job_number':'XYZ-J111111','ship_type':'c'},
                {'job_id':445672,'job_number':'XYZ-J222222','ship_type':'p'},
                {'job_id':896543,'job_number':'XYZ-J333333','ship_type':'f'}
            ]";
            JArray result = JArray.Parse(newJson);
            for (int i = 0; i < result.Count; i++)
            {
                Jobs.Add(new Job() { job_id = (string)result[i]["job_id"], job_number = (string)result[i]["job_number"], ship_type = (string)result[i]["ship_type"] });
            }
    
            lstJobData.ItemsSource = Jobs;
        }
    }
    
    internal class Job
    {
        public string job_id { get; set; }
        public string job_number { get; set; }
        public string ship_type { get; set; }
    }
