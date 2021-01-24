     public class MyObjectController : ApiController
    {
        public MyObject Post(MyObject myObject)
        {
             ModelState.Clear();
            // myObject shows up null here
            return myObject;
        }
    }
