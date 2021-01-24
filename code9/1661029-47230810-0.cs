    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using IBM.WMQ;
    
    /// <summary> Program Name
    /// MQTest51
    ///
    /// Description
    /// This C# class will connect to a remote queue manager
    /// and put a message to a queue under a managed .NET environment.
    ///
    /// Sample Command Line Parameters
    /// -h 127.0.0.1 -p 1414 -c TEST.CHL -m MQWT1 -q TEST.Q1
    ///
    /// </summary>
    namespace MQTest51
    {
       class MQTest51
       {
          private Hashtable inParms = null;
          private Hashtable qMgrProp = null;
          private System.String qManager;
          private System.String outputQName;
    
          /*
          * The constructor
          */
          public MQTest51()
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
             inParms = Hashtable.Synchronized(new Hashtable());
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
    
                qMgrProp = new Hashtable();
    
                qMgrProp.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
    
                qMgrProp.Add(MQC.HOST_NAME_PROPERTY, ((System.String)inParms["-h"]));
                qMgrProp.Add(MQC.CHANNEL_PROPERTY, ((System.String)inParms["-c"]));
    
                try
                {
                   qMgrProp.Add(MQC.PORT_PROPERTY, System.Int32.Parse((System.String)inParms["-p"]));
                }
                catch (System.FormatException e)
                {
                   qMgrProp.Add(MQC.PORT_PROPERTY, 1414);
                }
    
                if (inParms.ContainsKey("-u"))
                   qMgrProp.Add(MQC.USER_ID_PROPERTY, ((System.String)inParms["-u"]));
    
                if (inParms.ContainsKey("-x"))
                   qMgrProp.Add(MQC.PASSWORD_PROPERTY, ((System.String)inParms["-x"]));
    
                if ( (inParms.ContainsKey("-u")) && (inParms.ContainsKey("-x")) )
                   qMgrProp.Add(MQC.USE_MQCSP_AUTHENTICATION_PROPERTY, true);
             }
             else
             {
                throw new System.ArgumentException();
             }
          }
    
          /// <summary> Connect, open queue, write a message, close queue and disconnect.
          ///
          /// </summary>
          /// <throws>  MQException </throws>
          private void testSend()
          {
             System.String line;
             int openOptions = MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING;
    
             try
             {
                MQQueueManager _qMgr = new MQQueueManager(qManager, qMgrProp);
                System.Console.Out.WriteLine("MQTest51 successfully connected to " + qManager);
    
                MQQueue queue = _qMgr.AccessQueue(outputQName, openOptions, null, null, null); // no alternate user id
                System.Console.Out.WriteLine("MQTest51 successfully opened " + outputQName);
    
                MQPutMessageOptions pmo = new MQPutMessageOptions();
    
                // Define a simple MQ message, and write some text in UTF format..
                MQMessage sendmsg = new MQMessage();
                sendmsg.Format = MQC.MQFMT_STRING;
                sendmsg.Feedback = MQC.MQFB_NONE;
                sendmsg.MessageType = MQC.MQMT_DATAGRAM;
    
                line = "This is a test message embedded in the MQTest51 program.";
    
                sendmsg.MessageId = MQC.MQMI_NONE;
                sendmsg.CorrelationId = MQC.MQCI_NONE;
                sendmsg.WriteString(line);
    
                // put the message on the queue
    
                queue.Put(sendmsg, pmo);
                System.Console.Out.WriteLine("Message Data>>>" + line);
    
                queue.Close();
                System.Console.Out.WriteLine("MQTest51 closed: " + outputQName);
                _qMgr.Disconnect();
                System.Console.Out.WriteLine("MQTest51 disconnected from " + qManager);
             }
             catch (MQException mqex)
             {
                System.Console.Out.WriteLine("MQTest51 cc=" + mqex.CompletionCode + " : rc=" + mqex.ReasonCode);
             }
             catch (System.IO.IOException ioex)
             {
                System.Console.Out.WriteLine("MQTest51 ioex=" + ioex);
             }
          }
    
          /// <summary> main line</summary>
          /// <param name="args">
          /// </param>
          //        [STAThread]
          public static void Main(System.String[] args)
          {
             MQTest51 write = new MQTest51();
    
             try
             {
                write.init(args);
                write.testSend();
             }
             catch (System.ArgumentException e)
             {
                System.Console.Out.WriteLine("Usage: MQTest51 -h host -p port -c channel -m QueueManagerName -q QueueName [-u userID] [-x passwd]");
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
