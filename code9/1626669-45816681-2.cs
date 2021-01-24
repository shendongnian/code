    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    class IPPing
    {
        /// <summary>
        /// Ping List
        /// </summary>
        private static List<Ping> m_PingList = new List<Ping>();
        /// <summary>
        /// used like event Handler count  
        /// </summary>
        private static int m_nInstance = 0;
        /// <summary>
        /// Lock
        /// </summary>
        private static object @lock = new object();
        /// <summary>
        /// IpAddress
        /// </summary>
        private static IPAddress IpAddress { get; set; }
        /// <summary>
        /// Number of ip to check
        /// </summary>
        private static int NumberOfIp { get; set; }
        /// <summary>
        /// IpList
        /// </summary>
        private static List<IPAddress> IpList { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nNumberOfIp">Number of ip to check</param>
        /// <param name="StartIp">Start ip</param>
        public IPPing(int nNumberOfIp, IPAddress StartIp)
        {
            NumberOfIp = nNumberOfIp;
            IpAddress = StartIp;
            IpList = new List<IPAddress>();
        }
        public List<IPAddress> StartPing()
        {
            // Create ping request
            CreatePingers(NumberOfIp);
            PingOptions pingOption = new PingOptions(1, true);
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes("");
            // Used to wait thread for ping request to finished
            SpinWait wait = new SpinWait();
            // Send all ping Async
            foreach (Ping ping in m_PingList)
            {
                lock (@lock)
                {
                    m_nInstance += 1;
                }
                string sasd = IpAddress.ToString();
                ping.SendAsync(IpAddress.ToString(), 250, data, pingOption);
                IpAddress = GetNextIp(IpAddress);
            }
            // wait still all Pin_Completed finished
            while (m_nInstance > 0)
            {
                wait.SpinOnce();
            }
            DestroyPingers();
			return IpList;
        }
        /// <summary>
        /// Event is called when ping reqest finished 
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="e">Ping Completed Event Args</param>
        public static void Ping_completed(object obj, PingCompletedEventArgs e)
        {
            lock (@lock)
            {
                m_nInstance -= 1;
            }
            
            if (e.Reply.Status == IPStatus.Success)
            {
                IpList.Add(e.Reply.Address);            
            }
        }
        /// <summary>
        /// Used to create ping request
        /// </summary>
        /// <param name="nNumberOfPingRequest">Number of ping request</param>
        public static void CreatePingers(int nNumberOfPingRequest)
        {
            for (int i = 1; i <= nNumberOfPingRequest; i++)
            {
                Ping ping = new Ping();
                // Attached event to ping request
                ping.PingCompleted += Ping_completed;
                m_PingList.Add(ping);
            }
        }
        /// <summary>
        /// Used to destroy ping requestes
        /// </summary>
        public static void DestroyPingers()
        {
            foreach (Ping ping in m_PingList)
            {
                // Detach event
                ping.PingCompleted -= Ping_completed;
                ping.Dispose();
            }
            m_PingList.Clear();
        }
        /// <summary>
        /// Get next ip
        /// </summary>
        /// <param name="Ip">Ip address</param>
        /// <returns>Next ip</returns>
        public static IPAddress GetNextIp(IPAddress Ip)
        {
            byte[] barrIP = Ip.ToString().Split('.').Select(byte.Parse).ToArray();
            if (++barrIP[3] == 0)
            {
                if (++barrIP[2] == 0)
                {
                    if (++barrIP[1] == 0)
                    {
                        ++barrIP[0];
                    }
                }
            }
            return new IPAddress(barrIP);
        }
    }
