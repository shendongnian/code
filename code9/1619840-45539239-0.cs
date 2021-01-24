    FirebaseDatabase.DefaultInstance
      .GetReference("Users")
      .ValueChanged += HandleValueChanged;
    }
    void HandleValueChanged(object sender, ValueChangedEventArgs args) {
      if (args.DatabaseError != null) {
        Debug.LogError(args.DatabaseError.Message);
        return;
      }
      Debug.Log(arg.Snapshot.Child("Email").Value)
    }
