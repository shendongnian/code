    using System;
    using TwinCAT.Ads;
    using System.Threading;
    
    namespace WriteArrayToPLC
    {
        
        class Program
        {
            static void Main(string[] args)
            {
                TcAdsClient adsClient = new TcAdsClient();
                byte[] boolArray = new byte[100];
                // Fill array with 010101010...
                for (int i = 0; i < 100; i++)
                {
                    boolArray[i] = (i % 2 != 0) ? (byte)1 : (byte)0;
                }
                // Connect to PLC
                try
                {
    
                    if (adsClient != null)
                    {
                        Console.WriteLine("Connecting to PC");
                        adsClient.Connect(851);
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    adsClient = null;
                }
    
                if (adsClient != null)
                {
                    try
                    {
                        // Get the handle for the array
                        int handle_array = adsClient.CreateVariableHandle("MAIN.boolArray");
                        // Write the array to PLC
                        Console.WriteLine("Writing the array at handle: " + handle_array.ToString());
                        adsClient.WriteAny(handle_array, boolArray);
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                    // The end
                    Console.WriteLine("Done");
                    Thread.Sleep(3000);
                }
            }
        }
    }
