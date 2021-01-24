    public partial class SetVariable : Form
    {
      public string Test {get; private set;}
      
      //Just in case if you want to set value to Test property from other class.
      //If you want Test property readonly to other 
      //class you don't need this method.
      public void SetTest(string test)
      {
        Test = test;
      }
    }
    public class Main
    {
      SetVariable sv = new SetVariable();
      sv.SetTest("Some Value"); //unwanted to scenario. Just in case if you want
      //read Test value
      string testValue = sv.Test; //allowed
      //set Test value
      sv.Test = "Other value"; //not allowed.
    }
