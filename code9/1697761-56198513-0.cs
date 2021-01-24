csharp
/// <summary>
/// A modified type of <see cref="ResourceDictionary"/> that translates "Resource" pack URIs to "Site of Origin"
/// pack URIs when in runtime.
///
/// i.e. This allows you to declare pack URIs as "pack://application:,,,", which will be resolved
/// as such in design mode while at runtime, actually using "pack://siteoforigin:,,,".
/// </summary>
public class SiteOfOriginResourceDictionary : ResourceDictionary
{
    private const string SiteOfOriginPrefix = "pack://siteoforigin:,,,";
    private const string ApplicationPrefix = "pack://application:,,,";
    private const string UseRedirectSource = "Please use RedirectSource instead of Source";
    private string _originalUri;
    /// <summary>
    /// Gets or sets the design time source.
    /// </summary>
    public string RedirectSource
    {
        get => _originalUri;
        set
        {
            this._originalUri = value;
            bool isInDesignMode = (bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue;
            if (! isInDesignMode)
            {
                if (value.Contains(ApplicationPrefix))
                    value = value.Replace(ApplicationPrefix, SiteOfOriginPrefix);
            }
            base.Source = new Uri(value);
        }
    }
    /// <summary>
    /// Please use <see cref="RedirectSource"/> instead.
    /// </summary>
    public new Uri Source
    {
        get => throw new Exception(UseRedirectSource);
        set => throw new Exception(UseRedirectSource);
    }
}
**Usage Example**
xml
<ResourceDictionary.MergedDictionaries>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <SiteOfOriginResourceDictionary RedirectSource="pack://application:,,,/Theme/Default/Root.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</ResourceDictionary.MergedDictionaries>
------------
In practice, this solution has worked for me and I make active use of this code. I'm quite certain you can do the same with an `Image` and/or other WPF components.
That said, in my case, I only needed to support this on a `ResourceDictionary`. This solution would be unoptimal in your case as you would probably (eventually) require to do this for multiple controls down the road.
As such, I would propose as a potential solution to further investigate the use of `Attached Properties`, making a an attached property that sets the `Source` of a control, switching between `application` at design time and `siteoforigin` at runtime.
That instead could be re-used across multiple controls without having to inherit each time for each new control/class.
------------
On a related note, I can't say I know why using `application` works in the designer when the build action for a resource is set to `Content`. According to the documentation this URI is to be used when a resource *"is compiled into a referenced assembly"* ([Source][1]), but nonetheless this works for me. 
This is my first post on StackOverflow and I'm a hobbyist, so please take it easy on me .
  [1]: https://docs.microsoft.com/en-us/dotnet/framework/wpf/app-development/pack-uris-in-wpf#referenced-assembly-resource-file
