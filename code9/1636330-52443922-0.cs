    using System.Reflection;
    using System.Collections.Concurrent;
    using System.Linq;
    ...
    var connMan = Clients.All.GetType().GetField("_lifetimeManager", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Clients.All);
    var connsObj = connMan.GetType().GetField("_connections", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(connMan);
    ConcurrentDictionary<string, HubConnectionContext> conns = (ConcurrentDictionary<string, HubConnectionContext>)connsObj.GetType().GetField("_connections", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(connsObj);
    Console.WriteLine("Current connections: " + String.Join(",", conns.Values.ToList().Select(i => i.ConnectionId)));
