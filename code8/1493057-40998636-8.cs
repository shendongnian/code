	public class BookingVM : BindableBase
	{
		public BookingVM()
		{
            //Command binding in this situation is better than EventHandling as it allows you to specify requirements as well as actions
            //in this case that you can't save unless Type and Customer have been set
			Save = new DelegateCommand(
				() => Console.WriteLine("Save Clicked"), //ExecuteAction
				() => Type != null && Customer!=null //CanExecute
				);
		}
		private BoodkingTypeModel _Type;
		public BoodkingTypeModel Type
		{
			get { return _Type; }
            //this is triggered both when you change the values in the View via binding, and when you set the values via code meaning that you have a single point of entry so you don't need to check every place you alter the calue to be sure that its updates the control, also this value can be bound to no controls or 500 it doesn't matter its all handled automatically 
			set
			{
				if(SetProperty(ref _Type, value))
				{
					Save.RaiseCanExecuteChanged();
					OnPropertyChanged(nameof(Customers));//instruct all bindings on customers to refresh
				}
			}
		}
		public IEnumerable<BoodkingTypeModel> Types
		{
			get { return DummyDatabase.BoodkingTypes; }
		}
		private CustomerModel _Customer;
		public CustomerModel Customer
		{
			get { return _Customer; }
			set
			{
				if (SetProperty(ref _Customer, value))//SetProperty changes the property if the value has change and raises the event that updates binding
				{
					Save.RaiseCanExecuteChanged();//refresh command state
				}
			}
		}
		public IEnumerable<CustomerModel> Customers
		{
			get
			{
				return from c in DummyDatabase.Customers
					   where Type == null || c.BoodkingType.Contains(Type.ID)
					   select c;
			}
		}
		public DelegateCommand Save { get;  }
	}
