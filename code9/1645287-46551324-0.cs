    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace BMCVoiceStarter
    {
    	public class frmBrowser : Form
	{
		private const string URLPrefix = "http://";
		private const string URLPrefixS = "https://";
		private IContainer components;
		private WebBrowser webBrowser1;
		private string voiceChatURL = string.Empty;
		private string uID = string.Empty;
		private string pass = string.Empty;
		private NotifyIcon m_notifyicon;
		private ContextMenu m_menu;
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmBrowser));
			this.webBrowser1 = new WebBrowser();
			base.SuspendLayout();
			this.webBrowser1.Dock = DockStyle.Fill;
			this.webBrowser1.Location = new Point(0, 0);
			this.webBrowser1.MinimumSize = new Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new Size(804, 536);
			this.webBrowser1.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(804, 536);
			base.Controls.Add(this.webBrowser1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "frmBrowser";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Chat";
			base.ResumeLayout(false);
		}
		[DllImport("User32.dll")]
		public static extern int SetForegroundWindow(int hWnd);
		private void ParseCommandLineArguments()
		{
			string text = Environment.GetCommandLineArgs().Skip(1).FirstOrDefault<string>();
			if (!string.IsNullOrWhiteSpace(text))
			{
				string[] array = text.Split(new char[]
				{
					';'
				});
				for (int i = 0; i < array.Length; i++)
				{
					string text2 = array[i];
					if (!string.IsNullOrWhiteSpace(text2))
					{
						string[] array2 = text2.Split(new char[]
						{
							'='
						});
						string a;
						if (array2.Count<string>() == 2 && (a = array2[0]) != null)
						{
							if (!(a == "url"))
							{
								if (!(a == "uid"))
								{
									if (a == "pass")
									{
										this.pass = array2[1];
									}
								}
								else
								{
									this.uID = array2[1];
								}
							}
							else
							{
								this.voiceChatURL = array2[1];
							}
						}
					}
				}
			}
		}
		private bool ValidateArguments()
		{
			if (string.IsNullOrWhiteSpace(this.voiceChatURL))
			{
				MessageBox.Show("URL missing");
				return false;
			}
			if (string.IsNullOrWhiteSpace(this.uID))
			{
				MessageBox.Show("uID missing");
				return false;
			}
			return true;
		}
		private bool ValidateURL()
		{
			int num;
			int num2;
			if (this.voiceChatURL.CompareWildcard(string.Format("{0}*/*", "http://"), true))
			{
				num = this.voiceChatURL.IndexOf("http://") + "http://".Length;
				num2 = this.voiceChatURL.IndexOf('/', num);
			}
			else
			{
				if (!this.voiceChatURL.CompareWildcard(string.Format("{0}*/*", "https://"), true))
				{
					return true;
				}
				num = this.voiceChatURL.IndexOf("https://") + "http://".Length;
				num2 = this.voiceChatURL.IndexOf('/', num);
			}
			string arg = this.voiceChatURL.Substring(num, num2 - num);
			string text = Helper.HashData(string.Format("{0}:{1}", arg, "BMCVoiceStarter"));
			string key;
			switch (key = text)
			{
			case "BF05321D16974853B18C0F53DCC6FE27":
			case "98802C2BE4C213E35EFFAAD0C08FE0A6":
			case "C858839EB9D63ED19F056C7DFB58E435":
			case "C745078FA48F608992E61CE171F0E177":
			case "2E4992C259910BD4E2434992A0E7E75C":
			case "3ACB67FA5B46D7F8E4BF7978275D0C1A":
			case "83CF517BC614BF14265D2E1D6DC5D208":
			case "351BF60E1EA709BB07E629A705E99210":
			case "60BADFDD66FDD7AA42D2FA51C1137FDF":
			case "7FCC182B223DC096141278F3ADD255A9":
			case "ABC9082996C470F0ED45EB3D68ED243A":
			case "30F2F9DF800E220BB44484E0987F4633":
			case "4888F91CCDADA02F3A8CFD9610DB8884":
			case "B4FB3922D9376C50024261C79A9DB6CF":
			case "F71447ABE2296BBF380CCB999764F69F":
			case "623DAF13037BD7E2251E11C268F103B4":
			case "55D639CDFF739FDD23FD833552EBDCB1":
			case "1B2CA3C9F360A85A3A2C98F8518FDE0E":
			case "9A57B4B74A4D1FC3BF9E2D4D215C8C15":
			case "1DF439C58634981E45BD10D5ECCF8F91":
			case "C40B4B929A4DACFE250CDAA45C188045":
			case "CB9D4EABB87BE53B3568AC06E6C149F7":
			case "29A1B7B4AFB5FC599A999174D70BA7C1":
			case "CD31932F203A6925D012CEDF770AF825":
			case "7F49EDFCAC3595095DE2059C644CCB1B":
			case "DF4E754EF3BBB967A8186CC4F6E0787C":
			case "23E1BD4D36A19E5D1F4A9A7BC9C7B912":
			case "28310D07D32BA5B2AEF15D901E277033":
			case "32E2AF52F6520ADD026B88EC1CFE9F50":
			case "32298742427ABD179B0E38D8E7FA04F2":
			case "5587912CDB9A3E97227009A57F88C35D":
			case "3C8B6D4BBADEA2D56A33D273F35C29AF":
			case "A5FD7CF88F8D2302C58F064AF06AD442":
			case "DD335CA5276C295809F71B941797ED7A":
			case "4074808055C36A6C8192EB7465EE3EDE":
			case "AC13537983BF1D9B4C9D852354FEAB60":
			case "6BC78FD324D216A18B32B91070E6B4D8":
			case "888242F9545D1425075DF00B387787B1":
			case "EF234C011A8FE7DB9E3B64449A126AE8":
			case "3932EFDB37A48C9931261694601DBFE7":
			case "66906B1361572C93B227AB005F72522C":
			case "6AB63CF848C9D435A328B693906E7D19":
			case "097404C9369091073A6B1014D4067A46":
			case "0AE16C0CCDBEDE165E2E011779C12A29":
			case "0299FDFE5464B880A1DC714E28822748":
			case "0D2566BF3EBFFB7D06C79433BB9782B5":
			case "0E87C4EF5F72AADB217A4BACECFB23FC":
			case "00CF3DC266E928C2D146DE14DC8AFE15":
			case "03CFD8D8EB64BE4ACDB2DA37A3984C5C":
			case "09929CCCAC090633905AF967ADBAC522":
			case "04B834C9A36B2EBF2F710019678D9491":
			case "0936C5F080FFCA41A2C59495881A951B":
			case "03DD65E8FC6729A1A380033E5F621736":
			case "08743960D56E4DD914C914C91BA53814":
			case "0979EC98DEBAE2648A7AE80C66E4B5EF":
			case "0B0E9E669A3FE279967AB5F0EA9AA4E7":
			case "0F4D4419E146523371A181249DF76FA6":
			case "05FC88875E00082E2A69D3C86AB926D0":
			case "012C949D797C9319DBF992FCCD097798":
			case "0F8CFCECBA02C06ED94FC55F8976EB45":
			case "050513138F43867CC6947D865E87821C":
			case "06EB67267C75337F84450E39D30D3F3D":
			case "0A06E6A6441B393E25A6B41A88B2A527":
			case "080FC8C10A1596C600156144C51891DB":
			case "0416759211518EB0E2D0BD0BA8955EAA":
			case "0252E3D7B7ECD04A82C4D1C2C0A850B7":
			case "0D667DB00871C8C58D09A07EF4F6D6E0":
			case "04DAFB78979F174385F6158E9AD6CCA0":
			case "00F554033BF3407FE52D14ADB9BB22FD":
			case "06A0A36242886618971563A94D4CD2C5":
			case "0EEE67580F6570B180A2E03D0A92CC49":
			case "007780D3DD320FFC6F151487C42BD3C1":
			case "07401505EB323FF0E43B5AB0CFF431F7":
			case "1FD01B40B6D57C4DA394AD6110995013":
			case "1AE9DEF99779ED9D54F877CB5302A30F":
			case "0562911DEC37BA34044CB2CCB40B4D48":
			case "0A2607DB8A0F67252A78293C06A94DD2":
			case "050DB3CC1D74AF29AE92A1F74FC94DE2":
				return true;
			}
			return true;
		}
		private void AddTrayIcon()
		{
			this.m_menu = new ContextMenu();
			this.m_menu.MenuItems.Add(0, new MenuItem("Restore", new EventHandler(this.Restore_Click)));
			this.m_menu.MenuItems.Add(1, new MenuItem("Exit", new EventHandler(this.Exit_Click)));
			this.m_notifyicon = new NotifyIcon();
			this.m_notifyicon.Text = "BMC Voice Application";
			this.m_notifyicon.Visible = true;
			this.m_notifyicon.Icon = new Icon(base.GetType(), "Main.ico");
			this.m_notifyicon.ContextMenu = this.m_menu;
			this.m_notifyicon.DoubleClick += new EventHandler(this.Restore_Click);
		}
		private void RemoveTrayIcon()
		{
			if (this.m_notifyicon != null)
			{
				this.m_notifyicon.Dispose();
			}
		}
		protected void Restore_Click(object sender, EventArgs e)
		{
			base.Show();
			base.WindowState = FormWindowState.Normal;
			frmBrowser.SetForegroundWindow(base.Handle.ToInt32());
		}
		protected void Exit_Click(object sender, EventArgs e)
		{
			base.Close();
		}
		public frmBrowser()
		{
			this.InitializeComponent();
			base.Resize += new EventHandler(this.frmBrowser_Resize);
			base.FormClosed += new FormClosedEventHandler(this.frmBrowser_FormClosed);
			this.webBrowser1.DocumentTitleChanged += new EventHandler(this.webBrowser1_DocumentTitleChanged);
			this.ParseCommandLineArguments();
			if (!this.ValidateArguments() || !this.ValidateURL())
			{
				base.Load += delegate(object s, EventArgs e)
				{
					base.Close();
				};
				return;
			}
			this.AddTrayIcon();
			if (string.IsNullOrWhiteSpace(this.pass))
			{
				this.webBrowser1.Navigate(string.Format("{0}?uid={1}", this.voiceChatURL, this.uID));
				return;
			}
			this.webBrowser1.Navigate(string.Format("{0}?uid={1}&pass={2}", this.voiceChatURL, this.uID, Helper.EncodeTo64(this.pass)));
		}
		private void frmBrowser_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.RemoveTrayIcon();
		}
		private void frmBrowser_Resize(object sender, EventArgs e)
		{
			if (base.WindowState == FormWindowState.Minimized)
			{
				base.Hide();
			}
		}
		private void webBrowser1_DocumentTitleChanged(object sender, EventArgs e)
		{
			this.Text = this.webBrowser1.DocumentTitle;
		}
	}
    }
