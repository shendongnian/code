    var hubContext = new Mock<IHubContext<MyHub>>();
    hubContext.Setup( h => h.Clients )
              .Returns( m_hubClients.Object );
    var hubClients = new Mock<IHubClients>();
    var clientCallbacks = new Mock<IMyHubClient>();
    hubClients.As<IHubClients<IMyHubClient>>()
              .Setup( c => c.Client( "one" ) )
              .Returns( clientCallbacks.Object );
    
    clientCallbacks.Setup( c => c.myCallback( It.IsAny<string>() ) )
                   .Callback( ( stringp ) =>
                  {
    ...etc...
