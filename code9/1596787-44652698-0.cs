    public partial class SetVariable : Form
    {
      public string Test {get; private set;}
      public void SetTest(string test)
      {
        Test = test;
      }
    }
    public class Main
    {
      SetVariable sv = new SetVariable();
      sv.SetTest("Some Value");
      //read Test value
      string testValue = sv.Test; //allowed
      //set Test value
      sv.Test = "Other value"; //not allowed.
    }
