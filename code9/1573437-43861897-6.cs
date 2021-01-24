    public class DisposableReactiveObject : ReactiveObject, IDisposable {
       protected CompositeDisposable Cleanup { get; } = new CompositeDisposable;
       public void Dispose(){
           _Cleanup.Dispose();
       }
    }
   
