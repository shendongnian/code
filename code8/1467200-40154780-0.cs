    foreach (var usroffline in usersOnline.Except(newUsersOnline).ToList())
    {
           OnStatusChanged(this, new StatusChangedEventArgs() { User = usroffline, Status = Status.Offline });
           _tempUserOnline.Remove(usroffline);
    }
