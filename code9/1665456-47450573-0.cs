    public partial class Form1 : Form
    {
      CancellationTokenSource _cancelSource = null;
    
      public Form1()
      {
        InitializeComponent();
      }
    
      private async void btn_Start_Click(object sender, EventArgs e)
      {
        btn_Start.Enabled = false;
        lb_Result.Text    = "Countdown started...";
    
        if(_cancelSource == null)
          _cancelSource = new CancellationTokenSource();
        else if (_cancelSource.IsCancellationRequested)
        { 
          _cancelSource.Dispose();
          _cancelSource = new CancellationTokenSource();
        }
    
        bool countDownCancelled = await PerformCountdown(_cancelSource.Token);
    
        if(countDownCancelled)
          lb_Result.Text = "Countdown cancelled";
        else
          lb_Result.Text = "Countdown finished";
    
        btn_Start.Enabled = true;
      }
    
      private void btn_Cancel_Click(object sender, EventArgs e)
      {
        if (_cancelSource != null && !_cancelSource.IsCancellationRequested)
          _cancelSource.Cancel();
      }
    
      private void UpdateTimeLabel(int remainingSeconds)
      {
        lb_Timer.Text = string.Format("0: {0}s", remainingSeconds);
      }
    
      private async Task<bool> PerformCountdown(CancellationToken cancelToken)
      {
        bool cancelled = false;
    
        try
        {
          int timeLeft = 3;
    
          Invoke((MethodInvoker)delegate() { UpdateTimeLabel(timeLeft); });
          do
          {
            await Task.Delay(1000, cancelToken);
    
            if (cancelToken.IsCancellationRequested)
              break;
    
            timeLeft--;
            Invoke((MethodInvoker)delegate() { UpdateTimeLabel(timeLeft); });
          }
          while (timeLeft > 0);
        }
        catch (OperationCanceledException)
        {
          cancelled = true;
          Debug.WriteLine("PerformCountdown cancelled");
        }
        catch (Exception ex)
        {
          Debug.WriteLine("PerformCountdown unhandled exception: " + ex);
        }
    
        return cancelled;
      }
    }
