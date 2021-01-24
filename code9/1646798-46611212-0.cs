	public partial class App : Form {
		//Some codes omitted
		public EditProcess Process = new EditProcess(ProcessTextBox);
		private void ExecuteBtn_Click (object sender, EventArgs e) {
			//DnldBgWorker is a backgroundWorker.
			Download Dnld = new Download(dir, Process);
			DnldBgWorker.DoWork += (obj, e) => GoDownload(Dnld, urllist, e);
			DnldBgWorker.RunWorkerAsync();
			DnldBgWorker.RunWorkerCompleted += (obj, e) => FinishExecution();
			DnldBgWorker.ProgressChanged += (s, e) => EditProcess.Text((string)e.UserState);;
		}
		private void GoDownload(Download Dnld, string[] urllist, EventArgs e) {
			foreach(string url in urllist) {
				Dnld.Dnld(url);
				DnldBgWorker.ReportProgress(0, String.Format($"Downloaded: {url}\r\n"));
				if (DnldBgWorker.CancellationPending) {
					e.Cancel = true;
					return;
				}
			}
		}
		private void StopBtn_Click(object sender, EventArgs e) {
			DnldBgWorker.CancelAsync();
		}
	}
	public class Download {
		// Some codes omitted
		public WebClient client = new WebClient();
		public EditProcess Process;
		public Download(string dir, EditProcess Process) {
			this.dir = dir;
			this.Process = Process;
		}
		public void Dnld() {
			client.DownloadFile(url, dir);
		}
	}
	public class EditProcess {
		public TextBox Box;
		public EditProcess(TextBox Box) {
			this.Box = Box;
		}
		public void Text(string textToAdd) {
			Box.Text += textToAdd;
		}
	}
