    void SomeMethod(){
        ISelectedColorContainer items = new ISelectedColorContainer[] {
          new EnglishPickerImplementation(), new PhotographyPickerImplementation()};
       foreach(var item in items){
         
        var labelFirst = UpdateSetting(item);
        var labelLast = item.SelectedColorText.Substring(3, 6);
        var label = labelFirst + labelLast;
       }
    } 
    string UpdateSetting(ISelectedColorContainer input){
         return  input.SelectedColorText.Substring(0, 1);
    }
