    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication14
    {
        public partial class Form1 : Form
        {
            private readonly Object obj = new Object();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                LaunchThreads("D:\\log.txt");
            }
    
            public void LaunchThreads(string path_file)
            {
                int i = 0;
                int MAX_THREAD = 10;
                Dictionary<int, Thread> threadsdico = new Dictionary<int, Thread>();
                while (i < MAX_THREAD)
                {
                    Thread thread = new Thread(() => ThreadEntryWriter(path_file, string.Format("ThreadsWriters{0}", i)));
                        thread.Name = string.Format("ThreadsWriters{0}", i);
                        threadsdico.Add(i, thread);
                        thread.Start();
                        i++;
                }
                int zz = 0;
                while (zz < threadsdico.Count())
                {
                    threadsdico[zz].Join();
                    zz++;
                }
            }
    
            public void ThreadEntryWriter(string path_file,string threadName)
            {
                int w = 0;
                while (w < 99)
                {
                    string newline = w + " - test" + " Thread:" + threadName + "\r\n";
                    lock (obj)
                    {
                        string txt = File.ReadAllText(path_file);
                        using (TextWriter myWriter = new StreamWriter(path_file))
                        {
                            TextWriter.Synchronized(myWriter).Write(txt + newline);
                        }
                    }
                    w++;
                }
            }
        }
    }
