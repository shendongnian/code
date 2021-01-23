    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Microsoft.Owin;
    
    namespace NoteApp.WebService.Controller {
       using System;
       using System.Net.WebSockets;
       using System.Text;
       using System.Threading;
       using System.Threading.Tasks;
       using NoteApp.WebService.Handler;
       using WebSocketAccept = System.Action<
                                    System.Collections.Generic.IDictionary<string, object>, // WebSocket Accept parameters
                                    System.Func< // WebSocketFunc callback
                                        System.Collections.Generic.IDictionary<string, object>, // WebSocket environment
                                        System.Threading.Tasks.Task>>;
       using WebSocketCloseAsync = System.Func<
                                        int, // closeStatus
                                        string, // closeDescription
                                        System.Threading.CancellationToken, // cancel
                                        System.Threading.Tasks.Task>;
       using WebSocketReceiveAsync = System.Func<
                      System.ArraySegment<byte>, // data
                      System.Threading.CancellationToken, // cancel
                      System.Threading.Tasks.Task<
                          System.Tuple< // WebSocketReceiveTuple
                              int, // messageType
                              bool, // endOfMessage
                              int>>>; // count
       // closeStatusDescription
       using WebSocketReceiveResult = System.Tuple<int, bool, int>;
       using WebSocketSendAsync = System.Func<
                                           System.ArraySegment<byte>, // data
                                           int, // message type
                                           bool, // end of message
                                           System.Threading.CancellationToken, // cancel
                                           System.Threading.Tasks.Task>;
    
       public class NoteController : ApiController {
          public HttpResponseMessage Get() {
             IOwinContext owinContext = Request.GetOwinContext();
    
             WebSocketAccept acceptToken = owinContext.Get<WebSocketAccept>("websocket.Accept");
             if (acceptToken != null) {
                var requestHeaders = GetValue<IDictionary<string, string[]>>(owinContext.Environment, "owin.RequestHeaders");
    
                Dictionary<string, object> acceptOptions = null;
                string[] subProtocols;
                if (requestHeaders.TryGetValue("Sec-WebSocket-Protocol", out subProtocols) && subProtocols.Length > 0) {
                   acceptOptions = new Dictionary<string, object>();
                   // Select the first one from the client
                   acceptOptions.Add("websocket.SubProtocol", subProtocols[0].Split(',').First().Trim());
                }
                acceptToken(acceptOptions, ProcessSocketConnection);
    
    
             } else {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
             }
             return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
          }
    
          private async Task ProcessSocketConnection(IDictionary<string, object> wsEnv) {
             var wsSendAsync = (WebSocketSendAsync)wsEnv["websocket.SendAsync"];
             var wsCloseAsync = (WebSocketCloseAsync)wsEnv["websocket.CloseAsync"];
             var wsCallCancelled = (CancellationToken)wsEnv["websocket.CallCancelled"];
             var wsRecieveAsync = (WebSocketReceiveAsync)wsEnv["websocket.ReceiveAsync"];
             
             //pass the sendasync tuple and the cancellation token to the handler. The handler uses the sendasync method to send message. Each connected client has access to this
             var handler = new NoteSocketHandler(wsSendAsync, CancellationToken.None);
             handler.OnOpen();
             var buffer = new ArraySegment<byte>(new byte[100]);
             try {
                object status;
                while (!wsEnv.TryGetValue("websocket.ClientCloseStatus", out status) || (int)status == 0) {
                   WebSocketReceiveResult webSocketResultTuple = await wsRecieveAsync(buffer, CancellationToken.None);                   
                   int count = webSocketResultTuple.Item3;
    
                   handler.OnMessage(Encoding.UTF8.GetString(buffer.Array, 0, count));
                }
             } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                throw ex;
             }
             handler.OnClose();
             await wsCloseAsync((int)WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
          }
    
          T GetValue<T>(IDictionary<string, object> env, string key) {
             object value;
             return env.TryGetValue(key, out value) && value is T ? (T)value : default(T);
          }
    
    
       }
    }
