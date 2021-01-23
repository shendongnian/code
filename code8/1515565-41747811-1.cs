    public static Task<Tuple<string, List<Variable>, Exception>>
                GetAsync(string ip, IEnumerable<string> vars, int timeout = 5000){
     TaskCompletionSource<Tuple<string,List<Variable>>> taskSource = 
           new TaskCompletionSource<Tuple<string,List<Variable>>>();
     Task.Run(async ()=> {
         var result = await GetAsync(ip,vars);
         taskSource.TrySetResult(result);
     });
     Task.Run(async ()=>{
         await Task.Delay(TimeSpan.FromSeconds(timeout));
         taskSource.TrySetCancelled();
     });
     return taskSource.Task;
    }
    private static async Task<Tuple<string, List<Variable>, Exception>>
                _GetAsync(string ip, IEnumerable<string> vars)
            {
                try
                {
                    IPAddress agentIp;
                    bool parsed = IPAddress.TryParse(ip, out agentIp);
                    if (!parsed)
                    {
                        foreach (IPAddress address in
                            Dns.GetHostAddresses(ip).Where(address => address.AddressFamily == AddressFamily.InterNetwork))
                        {
                            agentIp = address;
                            break;
                        }
    
                        if (agentIp == null)
                            throw new Exception("Impossibile inizializzare la classe CGesSnmp senza un indirizzo IP valido");
                    }
    
                    IPEndPoint receiver = new IPEndPoint(agentIp, LOCAL_PORT);
                    VersionCode version = VersionCode.V2;
                    string community = "public";
                    List<Variable> vList = new List<Variable>();
                    foreach (string s in vars)
                        vList.Add(new Variable(new ObjectIdentifier(s)));
                     // This is the function I want to "stop" or "kill" in some way
                    List<Variable> result = (List<Variable>)await Messenger.GetAsync(version, receiver, new OctetString(community), vList);
    
                    return new Tuple<string, List<Variable>, Exception>(ip, result, null);
                }
                catch (Exception ex)
                {
                    return new Tuple<string, List<Variable>, Exception>(ip, null, ex);
                }
            }  
