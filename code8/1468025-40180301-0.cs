    using System;
    using System.Runtime.InteropServices;
    namespace PowerPointTestApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (Container c = new Container())
                {
                    Console.WriteLine("Opened..");
                }
                Console.WriteLine("Closed..");
            }
        }
        public class Container: IDisposable
        {
            Microsoft.Office.Interop.PowerPoint.Application pp = new Microsoft.Office.Interop.PowerPoint.Application();
            public Container()
            {
                pp.PresentationOpen += (pres)=>
                {
                    //DoSomething
                };
      
                pp.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;  
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    pp.Quit();
                    Marshal.FinalReleaseComObject(pp);
                }         
            }
       
            ~Container()
            {            
                Dispose(false);
            }
        }
    }
