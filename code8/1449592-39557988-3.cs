    class UI_Update(){
    public string TextBox1_Text {get;set;}
    public int progressBar_Value = {get;set;}
    //...
    
     System.ComponentModel.BackgroundWorker updater = new System.ComponentModel.BackgroundWorker();
    public void initializeBackgroundWorker(){
        updater.DoWork += UI_Updater;
        updater.RunWorkerAsync();
    }
    public void UI_Updater(object sender, DoWorkEventArgs e){
       bool isRunning = true;
       while(isRunning){
          MethodInvoker mI = () => { 
          TextBox1.Text = TextBox1_Text; 
          myProgessBar.Value = progressBar.Value;
          };
          BeginInvoke(mI);
          System.Threading.Thread.Sleep(1000);
       }
     }
    }
