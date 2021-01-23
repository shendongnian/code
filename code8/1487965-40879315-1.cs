    using NUnit.Framework;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using UdpPractice;
    
    namespace UdpTest
    {
        [TestFixture ()]
        public class Test
        {
            [Test ()]
            public void TestCase ()
            {
                // Setup Listener
                int port = 14580;
                IPEndPoint locep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
                // Server (Listener)
                UdpCom com = new UdpCom (IPAddress.Any, port);
                // Set up sender
                UdpClient sender = new UdpClient();
                // Dummy Data
                byte [] dummyData = new byte[] {1, 2, 3, 4, 4, 5};
                sender.Send (dummyData, dummyData.Length, locep);
                sender.Send (dummyData, dummyData.Length, locep);
    			Thread.Sleep (100);
                Assert.AreEqual(true, com.receiveFlag);
            }
        }
    }
