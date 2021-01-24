    public dynamic myInfo;
      myInfo = fb.Get("/me?...........
      Type type = myInfo.GetType();
      foreach (var pi in type.GetProperties())
          {
            if (pi.Name.ToLower() == "education")
              {
                var val = pi.GetValue(myInfo).type;
                //do stuff to get child elements based on value
              }
          }
