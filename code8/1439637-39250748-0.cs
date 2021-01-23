    Assembly oAssemblyPresentationCore = typeof( Visual ).Assembly;
    Type oTypeMediaContext = oAssemblyPresentationCore.GetType( "System.Windows.Media.MediaContext" );
    MethodInfo oMethodInfoGetMediaContextFromDispatcher = oTypeMediaContext.GetMethod( "From", BindingFlags.Static | BindingFlags.NonPublic );
    object oMediaContext = oMethodInfoGetMediaContextFromDispatcher.Invoke( null, new object[] { oViewport3D.Dispatcher } );
    EventInfo oEventInfoRenderComplete = oMediaContext.GetType().GetEvent( "RenderComplete", BindingFlags.NonPublic | BindingFlags.Instance );
    oEventInfoRenderComplete.GetAddMethod( true ).Invoke( oMediaContext, new object[] { new EventHandler( EventHandlerRendered ) } );
