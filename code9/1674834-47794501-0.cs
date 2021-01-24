        private MemoryCache mc = new MemoryCache("CacheProvider"); // Creating memory cache object.
        public MainWindow()
        {
            InitializeComponent();
        }
        // Method to get cache elements.
        private void GetCache_Click(object sender, RoutedEventArgs e)
        {
            lstEmployeeID.Items.Clear();
            lstEmployeeName.Items.Clear();
            var emp = new Employee();
            foreach (Employee emp1 in emp.GetEmployeeList())
            {
                var cacheObj = mc[emp1.EmployeeName] as Employee; // typecasting it class object.
                if (cacheObj != null)
                {
                    lstEmployeeID.Items.Add(cacheObj.EmployeeId);
                    lstEmployeeName.Items.Add(cacheObj.EmployeeName);
                }
            }
        }
        
        // Saving class object to cache.
        private void SaveCache_Click(object sender, RoutedEventArgs e)
        {
             var emp = new Employee();
            foreach (Employee emp1 in emp.GetEmployeeList())
            {
                mc.Add(emp1.EmployeeName, emp1, DateTimeOffset.MaxValue); // adding (key, objectItem, CachingPolicy)
            }
        }
