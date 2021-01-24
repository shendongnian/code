    namespace USBSerialTest
    {
    	public partial class test1 : Form
    	{
    		private int check;
    		private int Progress;
            private MessageBoxResult UserDecision;
            private AutoResetEvent UserDecidedEvent = new AutoResetEvent(false);
            private string ErrorCode;
    
    		private byte[] Check_byte_Board1 = { 0x02, 0x01, 0x64, 0x06, 0x00, 0x00, 0x00, 0x80, 0xed };
    		private byte[] Check_byte_Board2 = { 0x02, 0x01, 0x64, 0x06, 0x00, 0x00, 0x00, 0x81, 0xee };
    
    		public test1()
    		{
    			InitializeComponent();
    			Shown += new EventHandler(test1_LoadForm);
    			backgroundWorker1.WorkerReportsProgress = true;
    			backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
    			backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
    
    			//backgroundWorker1.ProgressChanged += ShowWarning; Not working
    		}
    		void test1_LoadForm(object sender, EventArgs e)
    		{
    			backgroundWorker1.RunWorkerAsync();
    		}
    
    		void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    		{
    			Progress = 0;
    			backgroundWorker1.ReportProgress(Progress, "Checking for Board Function");
    			do                                                          //check if Board retruns an error
    			{
    				Motor.Instance.Check_Board();
    				if (Motor.Instance.buf.SequenceEqual(Check_byte_Board1) || Motor.Instance.buf.SequenceEqual(Check_byte_Board2))
    				{
    					check = 1;
    					Progress += 10;
    					//MessageBox.Show("test"); not working, just for testing here
    					backgroundWorker1.ReportProgress(Progress, "Checking for Board Function");
    
    				}
    				else
    				{
    					//here is the important part, when there is an error, I want to display the warning message
    					//and start the do-while loop from the start, all other message boxes where just to 
    					//test around if the general principle works
                        ErrorCode = "Boarddriver produce Errorcode ... Please Consult";
                        backgroundWorker1.ReportProgress(Progress, ErrorCode);
                        UserDecidedEvent.WaitOne();
                        if (UserDecision != DialogResult.Retry)
    					{
    						check = 1;
                            // Rewind checking of the board here to try the same 
                            // action again when calling Motor.Instance.Check_Board()
    					}
    					else
    					{
    						check = 0;
    					}
    				}
    			} while (check != 1);
    			backgroundWorker1.ReportProgress(Progress, "Succes");
    		}
    		// Back on the 'UI' thread so we can update the progress bar
    		void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    		{
                if (e.UserState == ErrorCode)
                {
                    UserDecision = MessageBox.Show("Boarddriver produce Errorcode ... Please Consult");
                    UserDecidedEvent.Set();
                }
                else
                {
                    progressBar1.Value = e.ProgressPercentage;
                    label1.Text = e.UserState.ToString();
                }
    		}
    	}
    }
