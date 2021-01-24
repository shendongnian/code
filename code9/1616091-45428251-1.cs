    public class Service1 : IService1
    {
        public string OutBid(school value)
        {
            return string.Format("The rollno is {0}", value.obj.rollno);
        }
    }
