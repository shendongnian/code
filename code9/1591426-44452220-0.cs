    InstallationForm f = new InstallationForm(new InstallationFormController());
    Application.Run(f);
    internal class InstallationFormController
    {
      public event EventHandler<DataEventArgsT<string>> NotificationTextChanged;
      public InstallationFormController()
      {
      }
      public void Initialize()
      {
        Task.Factory.StartNew(DoInstallation);
      }
      private void DoInstallation()
      {
        ...
        OnNotificationTextChanged(new DataEventArgsT<string>("Installation finished"));
      }
      private void OnNotificationTextChanged(DataEventArgsT<string> e)
      {
        if(NotificationTextChanged != null)
          NotificationTextChanged(this, e);
      }
    }
    
    public class DataEventArgsT<T> : EventArgs
    {
      ...
      public T Data { get; set; }
    }
    internal class InstallationForm : Form
    {
      private readonly InstallationFormController _controller;
      public InstallationForm()
      {
        InitializeComponent();
      }
      public InstallationForm(InstallationFormController controller) : this()
      {
        if(controller == null)
          throw new ArgumentNullException("controller")
        _controller = controller;
      }
      
      protected override void OnLoad(EventArgs e)
      {
        base.OnLoad(e);
        _controller.NotificationTextChanged += Controller_NotificationTextChanged;
        _controller.Initialize();
      }
      protected virtual void Controller_NotificationTextChanged(object sender, DataEventArgsT<string> e)
      {
        if(this.InvokeRequired)
        { // call this method on UI thread!!!
          var callback = new EventHandler<DataEventArgsT<string>>(Controller_NotificationTextChanged);
          this.Invoke(callback, new object[] {sender, e});
        }
        else
        {
          _myTextBox.Text = e.Data;
        }
      }
      ...
    }
    
