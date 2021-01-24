    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
     
            }
        }
        public enum ErrorTypes : int
        {
            RCV_BUFFER_EMPTY = 0,
            SUCCESS = 1
        }
        public class Test
        {
            [DllImport("pcmcanDLL.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
            internal static extern int ReadDatagram(int channel, ref uint msgID, IntPtr msgType, ref int msgLen, IntPtr dataPtr);
            private void rcvTimer_Tick(object sender, EventArgs e)
            {
                int channel = 1;
                String dsplyString = "Packet Received\n";
                uint msgID = 0;
                uint msgType = 0;
                int msgLen = 0;
                uint[] data = new uint[8];
                
                ErrorTypes dllReturn = ErrorTypes.RCV_BUFFER_EMPTY;
                IntPtr dataPtr = Marshal.AllocHGlobal(Marshal.SizeOf(data));
                IntPtr msgTypePtr = Marshal.AllocHGlobal(Marshal.SizeOf(msgType));
                do
                {
                    Marshal.StructureToPtr(msgType, msgTypePtr, true);
                    Marshal.StructureToPtr(data, dataPtr, true);
                    dllReturn = (ErrorTypes)ReadDatagram(channel, ref msgID, msgTypePtr, ref msgLen, dataPtr);
             
                    if (dllReturn != ErrorTypes.SUCCESS && dllReturn != ErrorTypes.RCV_BUFFER_EMPTY)
                    {
                        MessageBox.Show("Error receiving packet.", "Receipt Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else if (dllReturn == ErrorTypes.SUCCESS)
                    {
                       dsplyString = String.Format("{0}  {1}  {2}  {3}\n", channel, msgID, msgType, msgLen);
                    }
                } while (dllReturn != ErrorTypes.RCV_BUFFER_EMPTY);
                Marshal.FreeHGlobal(dataPtr);
                Marshal.FreeHGlobal(msgTypePtr);
            }
        }
    }
