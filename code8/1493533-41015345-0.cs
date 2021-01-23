    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication
    {
    class Program
    {
        static void Main(string[] args)
        {
            var sender = new Sender();
            var reciever = new Reciever(sender);
            sender.ProcessPacketBytes(null, byte.MaxValue);
            Console.ReadLine();
        }
    }
    /// <summary></summary>
    public class Sender
    {
        private readonly object _objectLock = new object();
        public event EventHandler PacketReceived
        {
            add
            {
                lock (_objectLock)
                {
                    PacketRecievedEvent += value;
                }
            }
            remove
            {
                lock (_objectLock)
                {
                    PacketRecievedEvent -= value;
                }
            }
        }
        private event EventHandler PacketRecievedEvent;
        public void ProcessPacketBytes(byte[] packetBytes, byte rxPacketSequence)
        {
            EventHandler handler = this.PacketRecievedEvent;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
    public class Reciever
    {
        public Reciever(Sender sendertest)
        {
            sendertest.PacketReceived += (sender, e) =>
            { Console.WriteLine(e.GetType()); };
        }
    }
}
