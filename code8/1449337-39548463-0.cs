    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
                //int WINAPI LogonNowait(Context* comm, 
                //  char*   host, 
                //  char*   username,
                //  char*   password,
                //  char*   shell_cmd,
                //  char*   logon_error_msg,
                //  int     buflen,
                //  SOCKET* sIO,
                //  SOCKET* sErr
                //  )
            [DllImport(@"C:\\MyDLL.dll")]
            public static extern int WaitForLogon(IntPtr ctx, IntPtr host, IntPtr username, IntPtr password, IntPtr shell_cmd,  IntPtr errmsg, int bLen, IntPtr sIO, IntPtr sErr);
            [DllImport("ws2_32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr socket(ADDRESS_FAMILIES_INT af, SOCKET_TYPE_INT socket_type, PROTOCOL_INT protocol);
            internal enum ADDRESS_FAMILIES_INT : int
            {
                /// <summary>
                /// Unspecified [value = 0].
                /// </summary>
                AF_UNSPEC = 0,
                /// <summary>
                /// Local to host (pipes, portals) [value = 1].
                /// </summary>
                AF_UNIX = 1,
                /// <summary>
                /// Internetwork: UDP, TCP, etc [value = 2].
                /// </summary>
                AF_INET = 2,
                /// <summary>
                /// Arpanet imp addresses [value = 3].
                /// </summary>
                AF_IMPLINK = 3,
                /// <summary>
                /// Pup protocols: e.g. BSP [value = 4].
                /// </summary>
                AF_PUP = 4,
                /// <summary>
                /// Mit CHAOS protocols [value = 5].
                /// </summary>
                AF_CHAOS = 5,
                /// <summary>
                /// XEROX NS protocols [value = 6].
                /// </summary>
                AF_NS = 6,
                /// <summary>
                /// IPX protocols: IPX, SPX, etc [value = 6].
                /// </summary>
                AF_IPX = 6,
                /// <summary>
                /// ISO protocols [value = 7].
                /// </summary>
                AF_ISO = 7,
                /// <summary>
                /// OSI is ISO [value = 7].
                /// </summary>
                AF_OSI = 7,
                /// <summary>
                /// european computer manufacturers [value = 8].
                /// </summary>
                AF_ECMA = 8,
                /// <summary>
                /// datakit protocols [value = 9].
                /// </summary>
                AF_DATAKIT = 9,
                /// <summary>
                /// CCITT protocols, X.25 etc [value = 10].
                /// </summary>
                AF_CCITT = 10,
                /// <summary>
                /// IBM SNA [value = 11].
                /// </summary>
                AF_SNA = 11,
                /// <summary>
                /// DECnet [value = 12].
                /// </summary>
                AF_DECnet = 12,
                /// <summary>
                /// Direct data link interface [value = 13].
                /// </summary>
                AF_DLI = 13,
                /// <summary>
                /// LAT [value = 14].
                /// </summary>
                AF_LAT = 14,
                /// <summary>
                /// NSC Hyperchannel [value = 15].
                /// </summary>
                AF_HYLINK = 15,
                /// <summary>
                /// AppleTalk [value = 16].
                /// </summary>
                AF_APPLETALK = 16,
                /// <summary>
                /// NetBios-style addresses [value = 17].
                /// </summary>
                AF_NETBIOS = 17,
                /// <summary>
                /// VoiceView [value = 18].
                /// </summary>
                AF_VOICEVIEW = 18,
                /// <summary>
                /// Protocols from Firefox [value = 19].
                /// </summary>
                AF_FIREFOX = 19,
                /// <summary>
                /// Somebody is using this! [value = 20].
                /// </summary>
                AF_UNKNOWN1 = 20,
                /// <summary>
                /// Banyan [value = 21].
                /// </summary>
                AF_BAN = 21,
                /// <summary>
                /// Native ATM Services [value = 22].
                /// </summary>
                AF_ATM = 22,
                /// <summary>
                /// Internetwork Version 6 [value = 23].
                /// </summary>
                AF_INET6 = 23,
                /// <summary>
                /// Microsoft Wolfpack [value = 24].
                /// </summary>
                AF_CLUSTER = 24,
                /// <summary>
                /// IEEE 1284.4 WG AF [value = 25].
                /// </summary>
                AF_12844 = 25,
                /// <summary>
                /// IrDA [value = 26].
                /// </summary>
                AF_IRDA = 26,
                /// <summary>
                /// Network Designers OSI &amp; gateway enabled protocols [value = 28].
                /// </summary>
                AF_NETDES = 28,
                /// <summary>
                /// [value = 29].
                /// </summary>
                AF_TCNPROCESS = 29,
                /// <summary>
                /// [value = 30].
                /// </summary>
                AF_TCNMESSAGE = 30,
                /// <summary>
                /// [value = 31].
                /// </summary>
                AF_ICLFXBM = 31
            }
            internal enum SOCKET_TYPE_INT : int
            {
                /// <summary>
                /// stream socket 
                /// </summary>
                SOCK_STREAM = 1,
                /// <summary>
                /// datagram socket 
                /// </summary>
                SOCK_DGRAM = 2,
                /// <summary>
                /// raw-protocol interface 
                /// </summary>
                SOCK_RAW = 3,
                /// <summary>
                /// reliably-delivered message 
                /// </summary>
                SOCK_RDM = 4,
                /// <summary>
                /// sequenced packet stream 
                /// </summary>
                SOCK_SEQPACKET = 5
            }
            internal enum PROTOCOL_INT : int
            {
                //dummy for IP  
                IPPROTO_IP = 0,
                //control message protocol  
                IPPROTO_ICMP = 1,
                //internet group management protocol  
                IPPROTO_IGMP = 2,
                //gateway^2 (deprecated)  
                IPPROTO_GGP = 3,
                //tcp  
                IPPROTO_TCP = 6,
                //pup  
                IPPROTO_PUP = 12,
                //user datagram protocol  
                IPPROTO_UDP = 17,
                //xns idp  
                IPPROTO_IDP = 22,
                //IPv6  
                IPPROTO_IPV6 = 41,
                //UNOFFICIAL net disk proto  
                IPPROTO_ND = 77,
                IPPROTO_ICLFXBM = 78,
                //raw IP packet  
                IPPROTO_RAW = 255,
                IPPROTO_MAX = 256
            }
            [StructLayout(LayoutKind.Sequential)]
            public struct CommContext
            {
                public uint inited;
                public uint rbufsize;
                public uint rbuf;
                public uint r_in_container;
                public uint left_in_container;
                public uint next_in_container;
                public uint wbufsize;
                public uint wbuf;
                public uint w_in_container;
                public uint first_free;
                public uint empty_container;
                public uint socket;
                public uint hdrtype;
                public uint last_error;
                public uint socket2;
                public string RX_context;
                public int port;
                public uint async_header;
                public string my_host_addr;
                public override string ToString()
                {
                    return port.ToString();
                }
            }
            static void Main(string[] args)
            {
                CommContext cmt = new CommContext();
                IntPtr cmtPtr = Marshal.AllocHGlobal(Marshal.SizeOf(cmt));
                Marshal.StructureToPtr(cmt, cmtPtr, true);
                string host = "LocalHost";
                byte[] hostBytes = Encoding.UTF8.GetBytes(host + "\0");
                IntPtr hostPtr = Marshal.AllocHGlobal(Marshal.SizeOf(hostBytes));
                Marshal.Copy(hostBytes, 0, hostPtr, hostBytes.Length);
                string username = "username";
                byte[] usernameBytes = Encoding.UTF8.GetBytes(username + "\0");
                IntPtr usernamePtr = Marshal.AllocHGlobal(Marshal.SizeOf(hostBytes));
                Marshal.Copy(usernameBytes, 0, usernamePtr, usernameBytes.Length);
                string password = "password";
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password + "\0");
                IntPtr passwordPtr = Marshal.AllocHGlobal(Marshal.SizeOf(passwordBytes));
                Marshal.Copy(passwordBytes, 0, passwordPtr, passwordBytes.Length);
                string shell_cmd = "shell_cmd";
                byte[] shell_cmdBytes = Encoding.UTF8.GetBytes(shell_cmd + "\0");
                IntPtr shell_cmdPtr = Marshal.AllocHGlobal(Marshal.SizeOf(shell_cmdBytes));
                Marshal.Copy(shell_cmdBytes, 0, shell_cmdPtr, shell_cmdBytes.Length);
                const int BUF_LEN = 256;
                IntPtr errmsgPtr = new IntPtr(BUF_LEN);
                int bLen = BUF_LEN;
                IntPtr sio = socket(ADDRESS_FAMILIES_INT.AF_INET, SOCKET_TYPE_INT.SOCK_DGRAM, PROTOCOL_INT.IPPROTO_TCP);
                IntPtr sErr = socket(ADDRESS_FAMILIES_INT.AF_INET, SOCKET_TYPE_INT.SOCK_DGRAM, PROTOCOL_INT.IPPROTO_TCP);
                int results = WaitForLogon(cmtPtr, hostPtr, usernamePtr, passwordPtr, shell_cmdPtr, errmsgPtr, bLen, sio, sErr);
            }
        }
    }
