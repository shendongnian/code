    using System.Runtime.CompilerServices;
    using System;
    [assembly:InternalsVisibleTo("my_friend_assembly")]
    internal class ExtensionManager : IExtensionManager, IDisposable 
    {
    }
