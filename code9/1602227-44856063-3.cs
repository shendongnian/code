    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR.Client;
    using System.Collections.Generic;
    using Xamarin.Forms;
    
    namespace SigClient
    {
    
        public class Client
        {
            public string _user = "";
            public string _prefix = "";
            public string _url = "";
            public int _port = 80;
    
            public string User
            {
                get
                {
                    return _user;
                }
                set
                {
                    _user = value;
                }
            }
            public string Prefix
            {
                get
                {
                    return _prefix;
                }
                set
                {
                    _prefix = value;
                }
            }
            public string HubUrl
            {
                get
                {
                    return _url;
                }
                set
                {
                    _url = value;
                }
            }
            public int Port
            {
                get
                {
                    return _port;
                }
                set
                {
                    _port = value;
                }
            }
    
    
            private HubConnection _connection;
            private IHubProxy _proxy;
    
    
            public void Clients(App1.MainPage page)
            {
                this.page=page;
                var querystringData = new Dictionary<string, string>();
                querystringData.Add("userName", "{\"userName\":\"" + _prefix + "_" + "driver" + _user + "\"}");
                _connection = new HubConnection(_url + ":" + _port.ToString(), querystringData);
                _proxy = _connection.CreateHubProxy("MyHub");
            }
    
            private App1.MainPage page;
            //public Label lbl;
            public async Task Connect()
            {
                try
                {
                    _proxy.On<string, string>("addNewMessageToPage", (name, msg) =>
    
                    page.PublicLbl.Text = msg 
                    //Debug.WriteLine(msg) //This line works fine
                    deb("", msg)
    
                    );
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
    
    
                await _connection.Start();
            }
    
            public async Task deb(string msg, string msg1)
            {
                //you don't need both of these lines
                page.PublicLbl.Text = msg1
                page.DoStuff(msg1);
                Debug.WriteLine(msg + "-" + msg1);
            }
            public Task Send(string message)
            {
                Debug.WriteLine("SignalR message sent");
                return _proxy.Invoke("SendToOperators", "eb5_operator123456", "NewJobSaved", "system");
            }
        }
    }
