    public class MainWindowModel
    {
            private PropertyChangedEventArgs pce;
    
            public MainWindowModel()
            {
                pce = new PropertyChangedEventArgs("");
            }
    
            private UserControl userControl;
            #region ControlProperty
            public UserControl ContentProperty {
                get
                {
                    return userControl;
                }
    
                set
                {
                    userControl = value;
                    PropertyChanged(this, pce);
                }
            }
            #endregion
    
            private DateTime dateTime;
            #region DateProperty
            public String DateProperty
            {
                get
                {
                    return dateTime.ToLongDateString();
                }
                set
                {
                    dateTime = DateTime.Parse(value);
                    PropertyChanged(this, pce);
                }
            }
            #endregion
    
            public String TimeProperty
            #region TimeProperty
            {
                get
                {
                    return dateTime.ToLongTimeString();
                }
                set
                {
                    dateTime = DateTime.Parse(value);
                    PropertyChanged(this, pce);
                }
            }
            #endregion
    
            private String title;
            public String TitleProperty
            #region TitleProperty
            {
                get
                {
                    return title;
                }
                set
                {
                    title = value;
                    PropertyChanged(this, pce);
                }
            }
            #endregion
    
            public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
     }
