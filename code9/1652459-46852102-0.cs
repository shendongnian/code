    public class MyWrapperClass 
    {
      ...
      public void createLabels(Control parent, string labelName)
      {
        Label label_Name = new Label();
        label_Name.ID = "label_Name";
        label_Name.Text = labelName;
        parent.Controls.Add(label_Name);
        Label get_Name = new Label();
        get_Name.ID = "get_Name";
        get_Name.Text = "Not found";
        parent.Controls.Add(get_Name);
      }
    }
    MyWrapperClass abc = new MyWrapperClass();
    abc.createLabels(this, "asdf");
