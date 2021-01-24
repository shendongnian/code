    using System;
    using IBM.WMQ;
    /// <summary> Program Name
    /// MQTest62B
    ///
    /// Description
    /// This C# class will connect to a remote queue manager
    /// and get (browse) a message from a queue using a managed .NET environment.
    ///
    /// Sample Command Line Parameters
    /// -h 127.0.0.1 -p 1415 -c TEST.CHL -m MQWT1 -q TEST.Q1
    /// </summary>
    /// <author>  Roger Lacroix, Capitalware Inc.
    /// </author>
    namespace MQTest62
    {
        public class MQTest62B
        {
            private System.Collections.Hashtable inParms = null;
            private System.String qManager;
            private System.String outputQName;
            private System.String userID = "tester";
            private System.String password = "barney";
            /*
            * The constructor
            */
            public MQTest62B()
                : base()
            {
            }
            /// <summary> Make sure the required parameters are present.</summary>
            /// <returns> true/false
            /// </returns>
            private bool allParamsPresent()
            {
                bool b = inParms.ContainsKey("-h") && inParms.ContainsKey("-p") &&
                         inParms.ContainsKey("-c") && inParms.ContainsKey("-m") &&
                         inParms.ContainsKey("-q");
                if (b)
                {
                    try
                    {
                        System.Int32.Parse((System.String)inParms["-p"]);
                    }
                    catch (System.FormatException e)
                    {
                        b = false;
                    }
                }
                return b;
            }
            /// <summary> Extract the command-line parameters and initialize the MQ variables.</summary>
            /// <param name="args">
            /// </param>
            /// <throws>  IllegalArgumentException </throws>
            private void init(System.String[] args)
            {
                inParms = System.Collections.Hashtable.Synchronized(new System.Collections.Hashtable(14));
                if (args.Length > 0 && (args.Length % 2) == 0)
                {
                    for (int i = 0; i < args.Length; i += 2)
                    {
                        inParms[args[i]] = args[i + 1];
                    }
                }
                else
                {
                    throw new System.ArgumentException();
                }
                if (allParamsPresent())
                {
                    qManager = ((System.String)inParms["-m"]);
                    outputQName = ((System.String)inParms["-q"]);
                    // Set up MQ environment
                    MQEnvironment.Hostname = ((System.String)inParms["-h"]);
                    MQEnvironment.Channel = ((System.String)inParms["-c"]);
                    try
                    {
                        MQEnvironment.Port = System.Int32.Parse((System.String)inParms["-p"]);
                    }
                    catch (System.FormatException e)
                    {
                        MQEnvironment.Port = 1414;
                    }
                    if (userID != null)
                        MQEnvironment.UserId = userID;
                    if (password != null)
                        MQEnvironment.Password = password;
                }
                else
                {
                    throw new System.ArgumentException();
                }
            }
            /// <summary> Connect, open queue, read (browse) a message, close queue and disconnect. </summary>
            ///
            private void testReceive()
            {
                MQQueueManager qMgr = null;
                MQQueue inQ = null;
                int openOptions = MQC.MQOO_BROWSE + MQC.MQOO_FAIL_IF_QUIESCING;
                try
                {
                    qMgr = new MQQueueManager(qManager);
                    System.Console.Out.WriteLine("MQTest62B successfully connected to " + qManager);
                    inQ = qMgr.AccessQueue(outputQName, openOptions, null, null, null); // no alternate user id
                    System.Console.Out.WriteLine("MQTest62B successfully opened " + outputQName);
                    testLoop(inQ);
                }
                catch (MQException mqex)
                {
                    System.Console.Out.WriteLine("MQTest62B cc=" + mqex.CompletionCode + " : rc=" + mqex.ReasonCode);
                }
                catch (System.IO.IOException ioex)
                {
                    System.Console.Out.WriteLine("MQTest62B ioex=" + ioex);
                }
                finally
                {
                   try
                   {
                       if (inQ != null)
                           inQ.Close();
                       System.Console.Out.WriteLine("MQTest62B closed: " + outputQName);
                   }
                   catch (MQException mqex)
                   {
                       System.Console.Out.WriteLine("MQTest62B cc=" + mqex.CompletionCode + " : rc=" + mqex.ReasonCode);
                   }
                   try
                   {
                       if (qMgr != null)
                           qMgr.Disconnect();
                       System.Console.Out.WriteLine("MQTest62B disconnected from " + qManager);
                   }
                   catch (MQException mqex)
                   {
                       System.Console.Out.WriteLine("MQTest62B cc=" + mqex.CompletionCode + " : rc=" + mqex.ReasonCode);
                   }
                }
            }
            private void testLoop(MQQueue inQ)
            {
                bool flag = true;
                MQMessage msg = new MQMessage();
                MQGetMessageOptions gmo = new MQGetMessageOptions();
                gmo.Options |= MQC.MQGMO_BROWSE_NEXT | MQC.MQGMO_WAIT | MQC.MQGMO_FAIL_IF_QUIESCING;
                gmo.WaitInterval = 500;  // 1/2 second wait time   or MQC.MQEI_UNLIMITED
                while (flag)
                {
                    try
                    {
                        msg = new MQMessage();
                        inQ.Get(msg, gmo);
                        System.Console.Out.WriteLine("Message Data: " + msg.ReadString(msg.MessageLength));
                    }
                    catch (MQException mqex)
                    {
                        System.Console.Out.WriteLine("MQTest62B CC=" + mqex.CompletionCode + " : RC=" + mqex.ReasonCode);
                        if (mqex.Reason == MQC.MQRC_NO_MSG_AVAILABLE)
                        {
                            // no meesage - life is good - loop again
                        }
                        else
                        {
                            flag = false;  // severe error - time to exit
                        }
                    }
                    catch (System.IO.IOException ioex)
                    {
                        System.Console.Out.WriteLine("MQTest62B ioex=" + ioex);
                    }
                }
            }
            /// <summary> main line</summary>
            /// <param name="args">
            /// </param>
            //        [STAThread]
            public static void Main(System.String[] args)
            {
                MQTest62B write = new MQTest62B();
                try
                {
                    write.init(args);
                    write.testReceive();
                }
                catch (System.ArgumentException e)
                {
                    System.Console.Out.WriteLine("Usage: MQTest62B -h host -p port -c channel -m QueueManagerName -q QueueName");
                    System.Environment.Exit(1);
                }
                catch (MQException e)
                {
                    System.Console.Out.WriteLine(e);
                    System.Environment.Exit(1);
                }
                System.Environment.Exit(0);
            }
        }
    }
