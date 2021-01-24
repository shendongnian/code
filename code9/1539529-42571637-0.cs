    namespace MainMenu.ViewModel {
    public class UsersGridViewModel : ViewModelBase {
        public UsersGridViewModel() {
            Init();
        }
        private void Init() {
            using (var conn = new FbConnection(Config.connString)) {
                //populate users grid
                IEnumerable<GridUsers_row> c_useri = conn.Query(@"select aa.id, aa.nume, aa.dela 
                                                                from useri aa 
                                                                where aa.deleted=0 and aa.dela is not null
                                                                order by aa.nume")
                                                     .Select(row => new GridUsers_row() {
                                                         IdUser = row.ID,
                                                         NumeUser = row.NUME,
                                                         ldDela = row.DELA.ToString(),
                                                     });
                Application.Current.Dispatcher.Invoke(() => {
                    GridUsersTable.Clear();
                    GridUsersTable.AddRange(c_useri);
                });
            }
        }
        //c_useri
        private ObservableRangeCollection<GridUsers_row> _gridUsers = new ObservableRangeCollection<GridUsers_row>();
        public ObservableRangeCollection<GridUsers_row> GridUsersTable
        {
            get { return _gridUsers; }
            set
            {
                if (_gridUsers == value)
                    return;
                _gridUsers = value;
                RaisePropertyChanged("GridUsersTable");
            }
        }
    }
    }
