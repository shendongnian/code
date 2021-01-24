    public class YourViewModel : INotifyPropertyChanged //Implement INPC to update the view when a property changes
    {
    
        private DateTime bookingDate;
        public DateTime BookingDate 
        {
            get { return bookingDate; }
            set 
            { 
                bookingDate = value;
                OnPropertyChanged("BookingDate");   //Call INPC Interface when property changes, so the view will know it has to update
            }
        }
        private void ChangeDate(DateTime newDate)
        {
            BookingDate = newDate;  //Assing your new date to your property
        }
    }
