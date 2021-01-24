    public class Foo : DisposableReactiveObject {
       public Foo(IObservable<int> observable){
       
           observable
                .Subscribe(x=>Console.WriteLine("WhooHoo"))
                .DisposeWith(Cleanup);
                
       }
    }
      
