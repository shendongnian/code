    namespace Windows.UI.Xaml
    {
    //Summary:
    //Represents an object that participates in the dependency property system. DependencyObject is the immediate base class of many `enter code here` important UI-related classes, such as UIElement, Geometry, FrameworkTemplate, Style, and ResourceDictionary.
    public class DependencyObject : IDependencyObject, IDependencyObject2
    {
        //Summary:
        //Gets the CoreDispatcher that this object is associated with. The CoreDispatcher represents a facility that can access the DependencyObject on the UI thread even if the code is initiated by a non-UI thread.
        // Returns: The CoreDispatcher that DependencyObject object is associated with, which represents the UI thread.
        public CoreDispatcher Dispatcher { get; }
    (...)
    }
    }
