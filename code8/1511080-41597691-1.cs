    public class ReservationViewModel:INotifyPropertyCHanged
    {
        public Reservation Reservation{get;set;} //Link to model
        private DateTime _Date;
        public DateTime Date
        {
	        get { return _Date; }
        	set { SetProperty(ref _Date, value); }
        }
        private string _Name;
        public string Name
        {
	        get { return _Name; }
        	set { SetProperty(ref _Name, value); }
        }
        public void SetProperty<T>(ref T store, T value,[CallerMemberName] string name = null)
        {
            store = value;
            if(PropertyChanged!=null)PropertyChanged(this,new PropertyChangedArgs(name);
        }
        public void Save(){/*validate, copy over model values call models save*/}
        public void Cancel(){/*change VM values back to Model values*/}
        public void Delete(){/*validate, call models delete*/}
        //ect
    }
