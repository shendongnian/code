    abstract class ClassBase
    {
       public void LoopThroughStuff(int i)
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
       public virtual  void DoSomething1(int x, int k)
       {
         //DO STUFF
       }
     }
    public class Class2 : ClassBase
    {
      public override void DoSomething1(int j, int k) 
      {
        //DO STUFF
      }
    }
