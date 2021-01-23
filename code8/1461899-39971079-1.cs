    using System.Linq;
    using System.Reflection;
    ...
    var view = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
    var runtimeMethods = view.GetType().GetRuntimeMethods();// get the runtime methods
    var tryEnterFullScreenMode = runtimeMethods.FirstOrDefault(x => x.Name == "TryEnterFullScreenMode");
    tryEnterFullScreenMode?.Invoke(view, null);//invoke the tryEnterFullScreenMode method.
