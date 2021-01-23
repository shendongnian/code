    class Program
    {
        static void Main(string[] args)
        {
            var test=new Test();
            test.Run();
            Console.ReadKey();
        }
        private class Test
        {
            AutoResetEvent _resetRIEvent = new AutoResetEvent(false);
            AutoResetEvent _resetHEvent = new AutoResetEvent(false);
            AutoResetEvent _resetSEvent = new AutoResetEvent(false);
            private BackgroundWorker bgwTestResInd = new BackgroundWorker();
            private BackgroundWorker bgwTestHipot=new BackgroundWorker();
            private BackgroundWorker bgwTestSurge=new BackgroundWorker();
            public async void Run()
            {
                bgwTestResInd.DoWork += BgwTestResInd_DoWork;
                bgwTestHipot.DoWork += BgwTestHipot_DoWork;
                bgwTestSurge.DoWork += BgwTestSurge_DoWork;
                await Task.Run(() => bgwTestResInd.RunWorkerAsync());
                _resetRIEvent.WaitOne();
                await Task.Run(() => bgwTestHipot.RunWorkerAsync());
                _resetHEvent.WaitOne();
                await Task.Run(() => bgwTestSurge.RunWorkerAsync());
                _resetSEvent.WaitOne();
                Console.Write("Done");
            }
            private void BgwTestHipot_DoWork(object sender, DoWorkEventArgs e)
            {
                Console.WriteLine("BgwTestHipot done..");
                _resetHEvent.Set();
            }
            private void BgwTestSurge_DoWork(object sender, DoWorkEventArgs e)
            {
                Console.WriteLine("BgwTestSurge done..");
                _resetSEvent.Set();
            }
            private void BgwTestResInd_DoWork(object sender, DoWorkEventArgs e)
            {
                Console.WriteLine("BgwTestResInd done..");
                _resetRIEvent.Set();
            }
        }
    }
