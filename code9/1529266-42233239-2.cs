    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using IBM.WMQ;
    namespace MQTest02
    {
       class MQTest02
       {
          private Hashtable inParms = null;
          private Hashtable qMgrProp = null;
          private System.String qManager;
          private System.String outputQName;
          /*
          * The constructor
          */
          public MQTest02()
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
                if (inParms.ContainsKey("-s"))
                   qMgrProp.Add(MQC.SECURITY_EXIT_PROPERTY, ((System.String)inParms["-s"]));
                System.Console.Out.WriteLine("MQTest02:");
                Console.WriteLine("  QMgrName ='{0}'", qManager);
                Console.WriteLine("  Output QName ='{0}'", outputQName);
                System.Console.Out.WriteLine("QMgr Property values:");
                foreach (DictionaryEntry de in qMgrProp)
                {
                   Console.WriteLine("  {0} = '{1}'", de.Key, de.Value);
                }
             }
             else
             {
                throw new System.ArgumentException();
             }
          }
          /// <summary> Connect, open queue, read a message, close queue and disconnect.
          ///
          /// </summary>
          /// <throws>  MQException </throws>
          private void testReceive()
          {
             MQQueueManager qMgr = null;
             MQQueue queue = null;
             int openOptions = MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING;
             MQGetMessageOptions gmo = new MQGetMessageOptions();
             MQMessage receiveMsg = null;
             try
             {
                qMgr = new MQQueueManager(qManager, qMgrProp);
                System.Console.Out.WriteLine("MQTest02 successfully connected to " + qManager);
                queue = qMgr.AccessQueue(outputQName, openOptions, null, null, null); // no alternate user id
                System.Console.Out.WriteLine("MQTest02 successfully opened " + outputQName);
                receiveMsg = new MQMessage();
                queue.Get(receiveMsg, gmo);
                System.Console.Out.WriteLine("Message Data>>>" + receiveMsg.ReadString(receiveMsg.MessageLength));
             }
             catch (MQException mqex)
             {
                System.Console.Out.WriteLine("MQTest02 cc=" + mqex.CompletionCode + " : rc=" + mqex.ReasonCode);
             }
             catch (System.IO.IOException ioex)
             {
                System.Console.Out.WriteLine("MQTest02 ioex=" + ioex);
             }
             finally
             {
                try
                {
                   queue.Close();
                   System.Console.Out.WriteLine("MQTest02 closed: " + outputQName);
                }
                catch (MQException mqex)
                {
                   System.Console.Out.WriteLine("MQTest02 cc=" + mqex.CompletionCode + " : rc=" + mqex.ReasonCode);
                }
                try
                {
                   qMgr.Disconnect();
                   System.Console.Out.WriteLine("MQTest02 disconnected from " + qManager);
                }
                catch (MQException mqex)
                {
                   System.Console.Out.WriteLine("MQTest02 cc=" + mqex.CompletionCode + " : rc=" + mqex.ReasonCode);
                }
             }
          }
          /// <summary> main line</summary>
          /// <param name="args">
          /// </param>
          //        [STAThread]
          public static void Main(System.String[] args)
          {
             MQTest02 mqt = new MQTest02();
             try
             {
                mqt.init(args);
                mqt.testReceive();
             }
             catch (System.ArgumentException e)
             {
                System.Console.Out.WriteLine("Usage: MQTest02 -h host -p port -c channel -m QueueManagerName -q QueueName [-u userID] [-x passwd] [-s securityExit]");
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
