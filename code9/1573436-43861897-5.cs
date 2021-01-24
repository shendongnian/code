    public class Foo : ReactiveObject, IDisposable {
       private CompositeDisposable _Cleanup = new CompositeDisposable();
       
       public Foo(IObservable<int> observable){
           observable
                .Subscribe(x=>Console.WriteLine("WhooHoo"))
                .DisposeWith(_Cleanup);
       }
       
       public void Dispose(){
           _Cleanup.Dispose();
       }
    }
   
