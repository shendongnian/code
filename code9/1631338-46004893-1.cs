    public void FillCollection(IReadOnlyList<ISomeDescriptiveNameHere> supportList) {
        foreach (var temp in supportList) {
           string yesno;
           if (temp.Id == CurrentId) {
               yesno = "" + yes;
           } else {
               yesno = "" + no;
           }
           CollectionSupport.Add(new SupportModel { Id = temp.Id, Name = temp.Name, Code = temp.Code, YesNo = "" + yesno });
       }
    }
