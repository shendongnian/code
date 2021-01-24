    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<ContactListViewModel>();
			SimpleIoc.Default.Register<MainViewModel>();
		}
		public static ContactListViewModel ContactListVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ContactListViewModel>();
            }
        }
		public static void CleanContactList()
		{
			SimpleIoc.Default.Unregister<ContactListViewModel>();
			SimpleIoc.Default.Register<ContactListViewModel>();
		}
		public static MainViewModel MainVM
		{
			get
			{
				return ServiceLocator.Current.GetInstance<MainViewModel>();
			}
		}
		public static void CleanMain()
		{
			SimpleIoc.Default.Unregister<MainViewModel>();
			SimpleIoc.Default.Register<MainViewModel>();
		}
		public static void Cleanup()
        {
			CleanMain();
            CleanContactList();
        }
    }
