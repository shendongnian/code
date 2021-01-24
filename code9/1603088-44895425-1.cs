        public void Handle(NavigationMessage message)
        {
            ShellViewModel Shell = (ShellViewModel)IoC.GetInstance(typeof(ShellViewModel), null);
            object Instance = null;
            foreach (var item in Shell.Items)
            {
                if (item.ToString().Contains(message.ViewModelType.ToString()))
                    Instance = item;
            }
            object AuxObject = new object();
            if (Instance == null)
            {
                try
                {
                    Instance = Activator.CreateInstance(message.ViewModelType, Shell.events);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            ActivateItem(Instance);
      
        }
