    public class testGenericClass<T> where T : IService
    {
        public void CallServiceMethod(T t, string technology, DateTime SDate, DateTime EDate, String someVariable)
        {
            t.AddData(technology, SDate, EDate, someVariable);
        }
    }
