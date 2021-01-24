    public partial class Form1 : Form {
    
    
        public Form1() {
    
          InitializeComponent();
          var l = new List<string>();
          for (int i = 0; i < 10; i++) {
            l.Add("Some Text" + i);
          }
          Task.Factory.StartNew(async () => {
            await GetFiles(l, this);
          });
        }
    
        
    
        private int ctrlCount = 0;
    
        public void AddControlToListView(Control c) {
          if (c is Label) {
            c.Location = new Point(205, ctrlCount * c.Height + 5);
          } else {
            c.Location = new Point(5, ctrlCount * c.Height + 5);
          }
         
          if (this.listView1.InvokeRequired) {
            this.listView1.Invoke(new Action<Control>(this.listView1.Controls.Add), c);
            this.listView1.Invoke(new Action(this.listView1.Update));
          } else {
            this.listView1.Controls.Add(c);
            this.listView1.Update();
          }
    
          ctrlCount++;
        }
    
        internal async Task GetFiles(IEnumerable<string> urlList, Form1 parent) {
          //string dir = Environment.CurrentDirectory + "\\updates";
         
          //Directory.CreateDirectory(dir);
          var tasks = new List<Task>();
    
          foreach (var url in urlList)
            tasks.Add(DownloadFile(url, ""));
    
          await Task.WhenAll(tasks);
        }
    
       
    
        internal async Task DownloadFile(string url, string dir) {
          string filename = "";// Helper.GetFilenameFromUrl(url);
          ProgressBar pb = CreateFileDownloadBar();
          Label lb = CreateFileDownloadLabel();
          this.AddControlToListView(pb);
          this.AddControlToListView(lb);
          Stopwatch sw = new Stopwatch();
          //Helper.CrossThreadInvoke(_sender, () => _sender.listView1.Controls.Add(pb));
          //Helper.CrossThreadInvoke(_sender, () => _sender.listView1.Controls.Add(lb));
          await Task.Factory.StartNew(() => {
            for (int i = 1; i < 11; i++) {
              pb.Invoke(new MethodInvoker(delegate {
                pb.Value = i * 10;
              }));
              lb.Invoke(new MethodInvoker(delegate {
                lb.Text = (i * 10).ToString();
              }));
              Thread.Sleep(500);
            }
          });
          using (var client = new WebClient()) {
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler((sender, e) => ProgressChanged(sender, e, sw, pb, lb));
            //client.DownloadFileCompleted += new AsyncCompletedEventHandler((sender, e) => Completed(sender, e, sw));
            //Helper.CrossThreadInvoke(_sender, () => _sender.lblFileDownload.Text = Helper.GetFilenameFromUrl(url));
            //await client.DownloadFileTaskAsync(url, string.Concat(dir, "\\", filename));
          }
        }
    
        private Label CreateFileDownloadLabel() {
          Label lb = new Label() {
            Text = "Hello"
            //Location = new System.Drawing.Point(_sender.offset - 180, 5 + offset)
          };
          return lb;
        }
    
        private ProgressBar CreateFileDownloadBar() {
          ProgressBar pb = new ProgressBar() {
            //Location = new System.Drawing.Point(5, 5 + offset),
            Size = new System.Drawing.Size(200, 20)
          };
    
          //offset += pb.Height + 5;
    
          return pb;
        }
    
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e, Stopwatch sw, ProgressBar pb, Label lb) {
          pb.Value = e.ProgressPercentage;
          lb.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
        }  
    
    }
