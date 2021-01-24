    public partial class MyViewModel : ViewModelBase
    {
        static MyDataContext _dataDC = new MyDataContext();//This class is from the Visual Studio DataDesigner Magic
        //There is a constructor here as well . . . skipped for brevity
        private ICommand _onRowEditEnding;
        public ICommand OnRowEditEnding
        {
            get { return _onRowEditEnding; }// set as new DelegateCommand(DocumentRowEditEvent) in the VM Constructor
        }
        public void DocumentRowEditEvent()
        {
             _dataDc.SubmitChanges(); //Refreshes the view as well
             return;
        }
    }
