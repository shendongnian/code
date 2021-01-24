    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Windows.Forms;
    namespace Experiments
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                // Ensuring that always the same amount of memory is used for point storage.
                bytesUsed = new Queue<long>(1000);
                var points = chart1.Series[0].Points;
                for (var i = 0; i < 1000; ++i)
                {
                    bytesUsed.Enqueue(0);
                    points.Add(0);
                }
                thread = new Thread(ThreadMethod);
                thread.Start();
                timer1.Interval = 10000;
                timer1.Enabled = true;
                timer1_Tick(null, null);
            }
            private readonly Queue<long> bytesUsed;
            private void timer1_Tick(object sender, EventArgs e)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                bytesUsed.Dequeue();
                bytesUsed.Enqueue(GC.GetTotalMemory(false));
                var points = chart1.Series[0].Points;
                points.Clear();
                foreach (var value in bytesUsed)
                    points.Add(value);
            }
            private Thread thread;
            private volatile bool stopping;
            private void ThreadMethod()
            {
                var random = new Random();
                while (!stopping)
                {
                    var constant = Expression.Constant(random.Next(), typeof(int));
                    var param = Expression.Parameter(typeof(int));
                    var mul = Expression.Multiply(param, constant);
                    var add = Expression.Multiply(mul, param);
                    var sub = Expression.Subtract(add, constant);
                    var lambda = Expression.Lambda<Func<int, int>>(sub, param);
                    var compiled = lambda.Compile();
                }
            }
            protected override void Dispose(bool disposing)
            {
                stopping = true;
                if (thread != null && disposing)
                    thread.Join();
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }
