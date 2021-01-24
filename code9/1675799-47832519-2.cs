    using System;
    
    namespace PlayAreaCSCon
    {
      internal class Program
      {
    	public static void Main(string[] args)
    	{
          var s = new Session();
          var c1 = new Page(1, s);
          c1.SetAction();
          c1 = null;
          var c2 = new Page(2, s);
          c2.InvokeAction();
          Console.ReadLine();
    	}
      }
    
      public class Session
      {
        public object Thingy;
      }
    
      public class Page
      {
        int _id;
        Session _session;
        public Page(int id, Session session)
        {
          _id = id;
          _session = session;
        }
    
        public Action OKFunction
        {
          get { return (Action)_session.Thingy; }
          set { _session.Thingy = value; }
        }
        public void SetAction()
        {
          OKFunction = DelegatedMethod;
        }
    
        public void DelegatedMethod()
        {
          Console.WriteLine($"Delegated method called on page {_id}");
        }
    
        public void InvokeAction()
        {
          OKFunction.Invoke();
        }
      }
    }
