    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            Button stopButton;
            System.Windows.Forms.Timer timer;
            public Form1()
            {
                //InitializeComponent();
                stopButton = new Button { Parent = this, Text = "Stop" };
                stopButton.Click += StopButton_Click;
                timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += Timer_Tick;
                timer.Start();
                Text = "Start";
            }
            private void StopButton_Click(object sender, EventArgs e)
            {
                timer.Stop();
                Text = "Stop";
            }
            private void Timer_Tick(object sender, EventArgs e)
            {
                var inputTexts = new BlockingCollection<string>();
                var inputNumbers = new BlockingCollection<string>();
                var readFiles = new Thread(() =>
                {
                    try
                    {
                        foreach (var file in Directory.EnumerateFiles("./Folder", "*.txt"))
                        {
                            string text = File.ReadAllText(file);
                            inputTexts.Add(text);
                        }
                    }
                    finally { inputTexts.CompleteAdding(); }
                });
                var processNumbers = new Thread(() =>
                {
                    try
                    {
                        foreach (var text in inputTexts.GetConsumingEnumerable())
                        {
                            int result;
                            if (int.TryParse(text, out result))
                                inputNumbers.Add(text);
                        }
                    }
                    finally { inputNumbers.CompleteAdding(); }
                });
                var createFiles = new Thread(() =>
                {
                    int counter = 0;
                    foreach (var number in inputNumbers.GetConsumingEnumerable())
                    {
                        File.WriteAllText("./Folder2/" + counter + ".txt", number);
                        counter++;
                    }
                });
                readFiles.Start();
                processNumbers.Start();
                createFiles.Start();
                readFiles.Join();
                processNumbers.Join();
                createFiles.Join();
            }
        }
    }
