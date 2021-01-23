    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    namespace stackoverflow
    {
        /// <summary>
        /// Interaction logic for AttendeeListControl.xaml
        /// </summary>
        /// 
        public partial class AttendeeListControl : UserControl
        {
            public AttendeeListViewModel vm { get; set; }
            public AttendeeListControl()
            {
                InitializeComponent();
                var emails = new List<string>() { "email@gmail.com", "email@aol.com", "email.yahoo.com", "email@msn.com" };
                var displayed = new ObservableCollection<string>() { emails[0], emails[1] };
                vm = new AttendeeListViewModel()
                 {
                     EmailList = emails,
                     DisplayList = displayed,
                     Expanded = false
                 };
                DataContext = vm;
                listBoxAttendees.ItemsSource = vm.DisplayList;
            }
            private void lblMore_Click(object sender, System.Windows.RoutedEventArgs e)
            {
                if (vm.Expanded)
                {
                    //remove all but last 2
                    do
                    {
                        vm.DisplayList.RemoveAt(vm.DisplayList.Count - 1);
                    } while (vm.DisplayList.Count > 2);
                    lblMore.Content = "Show More";
                }
                else
                {
                    //don't want the first 2
                    for (int i = 2; i < vm.EmailList.Count; i++)
                    {
                        vm.DisplayList.Add(vm.EmailList[i]);
                    }
                    lblMore.Content = "Show Less";
                }
                vm.Expanded = !vm.Expanded;
            }
        }
    }
