@GlideModule
public class XamarinGlideModule extends AppGlideModule {
    public static AppGlideModule InjectedModule;
    @Override
    public void registerComponents(Context context, Glide glide, Registry registry) {
        if(InjectedModule != null) {
            InjectedModule.registerComponents(context, glide, registry);
        }
    }
}
You will then need to wrap this library in an Android binding library.  Nothing is worthy of mention in this step, simply drop your built AAR in the binding project, add the matching version of the Glide Nuget and build.
You can then add a reference to that binding library in your app project.  In you Android Application class, you will need to setup the InjectedModule static property to inject your Xamarin implementation.  You must do this before any call to Glide, something similar to this :
public override void OnCreate()
{
    base.OnCreate();
    XamarinGlideModule.InjectedModule = new ZipArchiveLoaderModule();
    var temp = Glide.Get(this); // Init Glide, it will register your Xamarin module
}
