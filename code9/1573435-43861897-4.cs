    public class Foo : ReactiveObject, IDisposable {
       private CompositeDisposable _Cleanup = new CompositeDisposable();
       
       public Foo(IObservable<int> observable){
           var subscription = observable
                .Subscribe(x=>Console.WriteLine("WhooHoo"));
           _Cleanup.Add(subscription);     
           
       }
       
       public void Dispose(){
           _Cleanup.Dispose();
       }
    }
   
