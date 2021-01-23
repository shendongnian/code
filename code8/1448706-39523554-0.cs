    public class testGenericClass<T> where T : Web_Service, new()
    {
        public void CallServiceMethod(string technology, DateTime SDate, DateTime EDate, String someVariable)
        {
            new T().AddData(technology, SDate, EDate, someVariable);
        }
    }
    class Web_Service
    {
        public void AddData(string technology, DateTime SDate, DateTime EDate, String someVariable)
        { 
            //Call DAL method
        }
    }
