     public sealed partial class MainPage : Page
        {
            public List<dataRaw> t1;
            public List<dataRaw> t3;
            public ObservableCollection<dataRaw> t2;
            public MainPage()
            {
                this.InitializeComponent();
    
                t1 = collectionGenerator.getList();
                t2 = new ObservableCollection<dataRaw>(t1);
            }
    
            private void Filter_Click(object sender, RoutedEventArgs e)
            {
                t1 = collectionGenerator.getList();
                t2.Clear();
                string data = TB1.Text;
    
                if(data != "")
                {
                var Vtest = from VT in t1
                            where VT.firstName == data || VT.lastName == data
                            select VT;
                    foreach (var VT in Vtest)
                    {
                        t2.Add(new dataRaw { data = "1", firstName = VT.firstName, lastName = VT.lastName });
    
                    }
                }
                else
                {
                    var Vtest = from VT in t1
                                where VT.data == "1"
                                select VT;
                    foreach (var VT in Vtest)
                    {
                        t2.Add(new dataRaw { data = "1", firstName = VT.firstName, lastName = VT.lastName });
    
                    }
                }
              }
            }
