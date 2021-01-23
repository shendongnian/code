    abstract class ClassBase
    {
       public virtual void LoopThroughStuff(int i)
       {
          for (i = 0; i < 10; i++)
          {
            //DO A BUNCH OF STUFF
            DoSomething(i);
            //DO A BUNCH OF STUFF
           }
       }
       public virtual void DoSomething1(int x)
       {
          //DO STUFF
       }
       public virtual  void DoSomething1(int j, int k)
       {
         //you can keep this empty, as you will override it in Class2
       }
     }
    public class Class2 : ClassBase
    {
      public override void LoopThroughStuff(int i)
      {
         for (i = 0; i < 10; i++)
         {
            //DO A BUNCH OF STUFF
            // set k here as you like
            DoSomething(i,k);
           //DO A BUNCH OF STUFF
         }
      }
      public override void DoSomething1(int j, int k) 
      {
        //DO STUFF
      }
    }
