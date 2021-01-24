    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Threading;
    using System.Diagnostics;
    
    namespace TaskExample
    {
        public partial class Form1 : Form
        {
            //BackgroundWorker bw01, bw02, bw03, bw04;
            const int nmbRuns = 10;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                for (int cnt = 0; cnt < nmbRuns; cnt++)
                {
                    List<Task> allTasks = new List<Task>();
                    List<int> elements = new List<int>() { 0, 1, 2, 3 };
                    foreach (int i in elements)
                    {
                        Task t = Task.Run(() => Work(i));
                        //Task t = Task.Run(() => { Task.Delay(i + 1000); Debug.WriteLine(i + " started"); });
                        allTasks.Add(t);
                    }
                    Debug.WriteLine("All workers started");
                    Task.WaitAll(allTasks.ToArray());
                    Debug.WriteLine("All workers finished run " + cnt);
                }
                Debug.WriteLine("All done.");
            }
    
    
            private async Task<bool> Work(int id)
            {
                Debug.WriteLine(id + " awaiting.");
                await Task.Delay(1000 * id);
                Debug.WriteLine(id + " finished waiting.");
                return true;
            }
    
        }
    }
