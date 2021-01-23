        public CreateAssetViewModel CreateAssetVM
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<CreateAssetViewModel>())
                {
                    SimpleIoc.Default.Register<CreateAssetViewModel>();
                }
                return ServiceLocator.Current.GetInstance<CreateAssetViewModel>();
            }
        }
