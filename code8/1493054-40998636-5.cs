	public class CustomerModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int[] BoodkingType { get; set; }
	}
	public class BoodkingTypeModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
	}
	public static class DummyDatabase
	{
		public static IEnumerable<BoodkingTypeModel> BoodkingTypes { get; } = new BoodkingTypeModel[]
		{
			new BoodkingTypeModel { ID=1, Name="Type1"  },
			new BoodkingTypeModel { ID=2, Name="Type2"  },
			new BoodkingTypeModel { ID=3, Name="Type3"  },
			new BoodkingTypeModel { ID=4, Name="Type4"  },
		};
		public static IEnumerable<CustomerModel> Customers { get; } = new CustomerModel[]
		{
			new CustomerModel { ID=1, Name="Customer1" ,BoodkingType= new int[]{ 1,2,3,4 } },
			new CustomerModel { ID=1, Name="Customer2" ,BoodkingType= new int[]{ 1,2 } },
			new CustomerModel { ID=1, Name="Customer3" ,BoodkingType= new int[]{ 3,4 } },
			new CustomerModel { ID=1, Name="Customer4" ,BoodkingType= new int[]{ 1 } },
		};
	}
	public class BookingVM : BindableBase
	{
		public BookingVM()
		{
			Save = new DelegateCommand(
				() => Console.WriteLine("Save Clicked"), //ExecuteAction
				() => Type != null && Customer!=null //CanExecute
				);
		}
		private BoodkingTypeModel _Type;
		public BoodkingTypeModel Type
		{
			get { return _Type; }
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
