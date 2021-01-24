    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    namespace foo
    {
        class Packet
        {
            public double x;
            public double y;
            public double z;
        }
    
        public class Class1
        {
            Queue<Packet> qp;
    
            public Class1()
            {
                qp = new Queue<Packet>();
            }
    
            public void SendData(Packet p)
            {
                // prevent reader from accessing while we insert
                lock (qp)
                {
                    qp.Enqueue(p);
                }
            }
    
            public void ProcessIncomingPackets()
            {
                Packet p;
    
                // or until we decide to stop
                while (true)
                {
                    p = null;
    
                    // prevent the writer from adding while we're reading and maybe removing an item
                    lock (qp)
                    {
                        if (0 < qp.Count)
                        {
                            p = qp.Dequeue();
                        }
                    }
    
                    // with lock released, do something if we have a packet
                    if (null != p)
                    {
                        // graph, etc.
                    }
    
                    // spin faster for better responsiveness and more wasted CPU
                    Thread.Sleep(100); // milliseconds
                }
            }
    
        } // Class 1
    } // namespace
