    public UserInfo UserData[int row] {
        get {
           return new UserInfo { 
              FirstName = data.Rows[row]["firstname"].ToString(),
              //Remaining fields
           }
        }
        set {
            data.Rows[row]["firstname"] = value.FirstName;
            //Remaining fildes
        }
    }
