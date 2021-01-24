    //
    // ViewModel example
    //
    namespace WinFormMVVM.ViewModels
    {
	    public class HomeViewModel : ReactiveUI.ReactiveObject
    	{
	    	string ModelString;
		    public string EnteredText
		    {
			    get { return ModelString; }
			    set { this.RaiseAndSetIfChanged( ref ModelString, value);}
		    }
		    string statusString = "";
	    	public string Status
		    {
			    get{return statusString;}
			    set{this.RaiseAndSetIfChanged(ref statusString,value);}
		    }
		    public ReactiveCommand<object> OKCmd { get; private set; }
		    public HomeViewModel
		    {
                var OKCmdObs = this.WhenAny(vm => vm.EnteredText, 
                                            s => !string.IsNullOrWhiteSpace(s.Value));
                // OKCmd = ReactiveCommand.Create(OKCmdObs);    
                // OKCmd.Subscribe(_=> Status = EnteredText + " is saved.");
                OKCmd = ReactiveCommand.CreateFromObservable(() => {
                    Status = EnteredText + " is saved.";
                    return Observable.Return(true);
                }, OKCmdObs);
		    }
	    }
    }
