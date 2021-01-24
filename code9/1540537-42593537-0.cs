        using System;
        using System.Reflection;
        using System.Threading;
        namespace ConsoleApplication3
        {
            internal class Program
            {
                private static void Main(string[] args)
                {
                    var newThread = new Thread(DllLoader.DoWork);
                    newThread.Start();
                    //My other application Logic
                }
                public class DllLoader
                {
                    public enum ThingsICanDo
                    {
                        Jump,
                        Duck,
                        Run,
                        Quit
                    }
                    private static bool appStillRunning;
                    private static object myInstanceDllType;
                    private static void CheckForStuffToDo()
                    {
                        //Much better to use events, and pass the message inthe event
                        // then do what the message wants, and but I am keeping this breif 
                        // for this example.
                        var DoNext = (ThingsICanDo) Enum.Parse(typeof (ThingsICanDo), Console.ReadLine(), true);
                        switch (DoNext)
                        {
                            case ThingsICanDo.Jump:
                                //Do jump stuff
                                Console.WriteLine("Jump");
                                //myInstanceDllType.JumpStuff();
                                break;
                            case ThingsICanDo.Duck:
                                Console.WriteLine("Duck");
                                //myInstanceDllType.DuckStuff();
                                //Do duck stuff
                                break;
                            case ThingsICanDo.Run:
                                Console.WriteLine("Run");
                                //myInstanceDllType.RunStuff();
                                //Do run stuff
                                break;
                            case ThingsICanDo.Quit:
                                //Do exit stuff
                                Console.WriteLine("Bye");
                                Thread.CurrentThread.Abort();
                                break;
                        }
                    }
                    public static void DoWork()
                    {
                        var externalAssembly = Assembly.LoadFrom("/path/my.Dll");
                        myInstanceDllType = Activator.CreateInstance("DLLTypeINeed");
                        while (appStillRunning)
                        {
                            try
                            {
                                CheckForStuffToDo();
                            }
                            catch (Exception e)
                            {
                                //Log e
                                Console.WriteLine(e);
                            }
                            Thread.Sleep(1000);
                                //Much better to use semaphore.wait or something similar, but this is a simple example
                        }
                    }
                }
            }
        }
