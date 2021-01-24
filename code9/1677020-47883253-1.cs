        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new MainWindowViewModel(); 
            }
        }
    
    
    **MainWindowViewModel**
    using System.Collections.ObjectModel;
    using System.ComponentModel;
...
    
     public class MainWindowViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private ObservableCollection<Data> m_DataItems;
    
            public ObservableCollection<Data> DataItems
            {
                get { return m_DataItems; }
                set { m_DataItems = value; }
            }
    
    
            private Data m_SelectedDataRow;
            public Data SelectedDataRow
            {
                get { return m_SelectedDataRow; }
                set { m_SelectedDataRow = value; }
            }
    
    
            private string m_SelectedDisipline;
            public string SelectedDisipline
            {
                get { return m_SelectedDisipline; }
                set { m_SelectedDisipline = value; }
            }
    
            public MainWindowViewModel()
            {
                m_DataItems = new ObservableCollection<Data>();
    
                //Fill Items 
                Data data; 
                for (int i = 0; i < 10; i++)
                {
                    data = new Data();
                    m_DataItems.Add(data);
                }
            }
    
            private void OnPropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
        }
