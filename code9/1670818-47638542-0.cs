    public class ImageModel : MvxNotifyPropertyChanged
        {
            public int Id { get; set; }
            public string Name { get; set; }
            private bool upVoted ;
            public bool UpVoted 
            {
                get { return upVoted ; }
                set { upVoted = value; RaisePropertyChanged(() => UpVoted ); }
            }
        }
