    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class MyView : MvxActivity<MyViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var myValue = ViewModel.SomeProperty; // here you access your VM
        }
    }
