        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            ObservableCollection<IDepartmentInfo> caneRidgeDefaultDepartments = new ObservableCollection<IDepartmentInfo>
            {
                Container.Resolve<SCSC>(),
                Container.Resolve<ARS>()
            };
            ObservableCollection<IDepartmentInfo> testBuildingDepartmentInfos = new ObservableCollection<IDepartmentInfo>
            {
                Container.Resolve<HIIM>(),
                Container.Resolve<RandomDepartment>()
            };
            ObservableCollection<IBuilding> Buildings = new ObservableCollection<IBuilding>
            {
                Container.Resolve<CaneRidgeBuilding>(new ParameterOverride("departments",caneRidgeDefaultDepartments)),
                Container.Resolve<TestBuilding>(new ParameterOverride("departments",testBuildingDepartmentInfos))
            };
            Container.RegisterInstance(typeof(ObservableCollection<IBuilding>), Buildings, new ExternallyControlledLifetimeManager());
        }
