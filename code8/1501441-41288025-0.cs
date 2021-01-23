    public class ViewModel
    {
        public ViewModel()
        {
            Users = new ObservableCollection<UserRecord>((from users in UserRecord.Get().Where(d => d.Active == 1)
                                                          select new UserRecord
                                                          {
                                                              FName = users.FName,
                                                              SName = users.SName,
                                                              UserRecordId = users.UserRecordId,
                                                              Login = users.Login,
                                                              IsAdmin = users.IsAdmin,
                                                              UserRef = users.UserRef,
                                                              Disabled = users.Disabled,
                                                              Branch = users.Branch,
                                                              Department = users.Department,
                                                              Position = users.Position,
                                                              Salt = users.Salt,
                                                          }).OrderBy(d => d.Login).ToList());
        }
        public ObservableCollection<UserRecord> Users { get; }
    }
