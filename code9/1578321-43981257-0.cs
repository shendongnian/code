    public class BookWrapper : INotifyPropertyChanged, IDataErrorInfo
    {
       private Book _book;
         public Book Book 
       {
          get
           {
             return _book;
           }
          set
           {
             _book-value;
             NotifyPropertyChanged("Book");
           }
       }  
        public string Error
        {
            get { return String.Empty; }
        }
        public string this[string columnName]
        {
            get
            {
                String errorMessage = String.Empty;
                switch (columnName)
                {
                    case "Book":
                        if (Book.IsValid==false)
                        {
                            errorMessage = "Book not valid";
                        }
                        break;
                }
                return errorMessage;
            }
        }
      INotifyPropertyChanged Implementation...
    }
