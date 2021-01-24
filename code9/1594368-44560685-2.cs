    class MainWindowViewModel : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    	private bool _isButtonEnabled = true;
    	private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
    
    	public MainWindowViewModel()
    	{
    		ButtonCmd = new Command(OnButtonClick, () => IsButtonEnabled);
    	}
    	
    	public ICommand ButtonCmd { get; private set; }
    
    	public bool IsButtonEnabled
    	{
    		get
    		{
    			_lock.EnterReadLock();
    			bool result = _isButtonEnabled;
    			_lock.ExitReadLock();
    			return result;
    		}
    		set
    		{
    			_lock.EnterWriteLock();
    			_isButtonEnabled = value;
    			_lock.ExitWriteLock();
    			OnPropertychanged(nameof(IsButtonEnabled));
    		}
    	}        
    
    	private void OnButtonClick()
    	{
    		Task.Factory.StartNew(()=>{
    			IsButtonEnabled = false;
    			Thread.Sleep(1000);
    			IsButtonEnabled = true;
    		});
    	}       
    	private void OnPropertychanged(string name)
    	{
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    	}
    }
    
