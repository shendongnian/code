    public class ViewModelLocator
    {
      public UserControl1Model UserControl1Model { get; set; } = new UserControl1Model();
      public UserControl2Model UserControl2Model { get; set; } = new UserControl2Model();
      public ViewModelLocator
      {
        UserControl1Model.Message = "Hello";
        UserControl2Model.Message = "Test";  
      }
    }
