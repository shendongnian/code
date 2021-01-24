    [ComVisible(true)]
    [Guid("B523844E-1A41-4118-A0F0-FDFA7BCD77C9")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IAddinHelper
    {
        string GetPresentation();
        string GetString();
    }
    
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("A523844E-1A41-4118-A0F0-FDFA7BCD77C9")]
    [ComSourceInterfaces(typeof(IAddinHelper))]
    public class AddinHelper : StandardOleMarshalObject, IAddinHelper
