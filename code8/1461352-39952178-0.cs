    public partial class Form1 : Form
        {
            private object _sync;
            private ConcurrentQueue<string> _outputs;
            private bool _running;
            private delegate void OutputHandler(string line);
            private OutputHandler _append;
    
            public Form1()
            {
                InitializeComponent();
                _sync = new Object();
                _outputs = new ConcurrentQueue<string>();
                _append = new OutputHandler(line => {
                    textBox1.AppendText(line + "\r\n");
                });
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.OutputDataReceived += p_OutputDataReceived;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c @echo off";
                p.StartInfo.Arguments = "/c java -Xms512M -Xmx1G -XX:MaxPermSize=128M -XX:+UseConcMarkSweepGC -jar spigot.jar";
                p.Start();
                p.BeginOutputReadLine();
                lock(_sync)
                {
                    _running = true;
                }
                p.Exited += p_Exited;
                Task.Run(() => UpdateOutput());
            }
    
            void p_Exited(object sender, EventArgs e)
            {
                lock(_sync)
                {
                    _running = false;
                }
            }
    
            void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                if(e.Data != null)
                {
                    _outputs.Enqueue(e.Data);
                }
            }
    
            private async Task UpdateOutput()
            {
                await Task.Run(() =>
                {
                    var running = _running;
                    while (running)
                    {
                        var line = default(string);
                        if (_outputs.TryDequeue(out line))
                        {
                            try
                            {
                                textBox1.Invoke(_append, line);
                            }
                            catch
                            {
    
                            }
                        }
                        lock (_sync)
                        {
                            running = _running;
                        }
                    }
                });
            }
        }
