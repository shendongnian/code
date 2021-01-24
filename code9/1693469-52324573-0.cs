    [ComVisible(true)]
    public class MyScriptingClass{
        private string SomeData;
        public string GetSomeData(){
           return SomeData + " Something";
        }
        public void SetSomeData(string some){
           SomeData = some;
        }
    }
