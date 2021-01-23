    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    namespace stackoverflow
    {
        public class AttendeeListViewModel
        {
            public bool Expanded { get; set; }
            public List<string> EmailList { get; set; }
            public ObservableCollection<string> DisplayList { get; set; }
        }
    }
