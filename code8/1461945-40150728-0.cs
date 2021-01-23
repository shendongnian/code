     public sealed partial class MainPage : Page
        {
            public List<dataRaw> t1;
            public List<dataRaw> t3;
            public ObservableCollection<dataRaw> t2;
            public MainPage()
            {
                this.InitializeComponent();
                //So you call the information from a class file (normally in Models)
                t1 = collectionGenerator.getList();
                //Then you use the t1 (List<T>) and convert it to an ObservableCollection
                t2 = new ObservableCollection<dataRaw>(t1);
            }
    
            private void Filter_Click(object sender, RoutedEventArgs e)
            {
                //Gather user input from a textbox (TB1)
                // clear the data in ObservableCollection t2
                t1 = collectionGenerator.getList();
                t2.Clear();
                string data = TB1.Text;
                
                //Check what input the user have entered
                if(data != "")
                {
                var Vtest = from VT in t1
                            where VT.firstName == data || VT.lastName == data
                            select VT;
                    foreach (var VT in Vtest)
                    {
                        //Add the given data back to the t2
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
