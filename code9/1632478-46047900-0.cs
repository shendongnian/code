    [Table("Bills")]
    public class Bill : NotifyBase
    {
        //works !!
        private Discount m_Discount;
        public virtual Discount Discount
        {
    	    get { return m_Discount; }
    	    set { SetWithNotif(value, ref m_Discount); }
        }
    
    }
    
    [ComplexType]
    public class Discount : NotifyBase
    {
       //some props in here  
    }
    
     public class NotifyBase : INotifyPropertyChanged,INotifyPropertyChanging
     {       
        public void SetWithNotif<T>(T val,ref T field,[CallerMemberName] string prop = "" )
        {
            if (!field.Equals(val))
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(prop));
                field = val;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }
        [field: NotMapped]
        public event PropertyChangedEventHandler PropertyChanged;
        [field: NotMapped]
        public event PropertyChangingEventHandler PropertyChanging;
    }
