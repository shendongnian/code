        using System;
        using System.Management;
        namespace ConsoleApplication1
        {
            class Program
            {
                 static void Main(string[] args)
                 {
                      // create management class object
                      ManagementClass mc = new 
                      ManagementClass("Win32_ComputerSystem");
                      //collection to store all management objects
                      ManagementObjectCollection moc = mc.GetInstances();
                      if (moc.Count != 0)
                      {
                          foreach (ManagementObject mo in mc.GetInstances())
                          {
                               // display general system information
                               Console.WriteLine("\nMachine Make: {0}", mo["Manufacturer"].ToString());
                          }
                      }
                      //wait for user action
                      Console.ReadLine();
                  }
              }
          } 
