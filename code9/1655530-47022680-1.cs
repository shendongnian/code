    private static StringBuilder _erro = new StringBuilder();
    public static string ErrorMessage { get { return _erro.ToString(); } }
    public static bool Ping(string ipOrName, int timeout = 0, bool throwExceptionOnError = false)
            {
                bool p = false;
                try
                {
                    using (Ping ping = new Ping()) //using System.Net.NetworkInformation; (.NET Core namespace)
                    {
                        PingReply reply = null;
                        if (timeout > 0)
                            reply = ping.Send(ipOrName, timeout);
                        else
                            reply = ping.Send(ipOrName);
                        if (reply != null)
                            p = (reply.Status == IPStatus.Success);
                        //p = Convert.ToInt32(reply.RoundtripTime);
                    }
                }
                catch (PingException e)
                {
                    _erro.Append(e.Message);
                    _erro.Append(Environment.NewLine);
                    if (throwExceptionOnError) throw e;
                }
                catch (Exception ex)
                {
                    _erro.Append(ex.Message);
                    _erro.Append(Environment.NewLine);
                }
                return p;
            }
