        [Table(Name="dbo.Customer")]
	    public partial class Customer : INotifyPropertyChanging, 
                                        INotifyPropertyChanged, 
                                        ICustomer
	    {
		    private int _Id;
          
		    [Column(Storage="_Id", 
                    AutoSync=AutoSync.OnInsert, 
                    DbType="Int NOT NULL IDENTITY", 
                    IsPrimaryKey=true, 
                    IsDbGenerated=true)]
		    public int Id
		    {
			    get
			    {
				    return this._Id;
			    }
			    set
			    {
				    if ((this._Id != value))
				    {
					    this.OnIDChanging(value);
					    this.SendPropertyChanging();
					    this._Id = value;
					    this.SendPropertyChanged("Id");
					    this.OnIDChanged();
				    }
			    }
		    }
        }
