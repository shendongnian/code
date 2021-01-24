    public void Handle(NavigationMessage message)
    {
            ShellViewModel Shell = (ShellViewModel)IoC.GetInstance(typeof(ShellViewModel),null);
            object instance = new object();
    
            try
            {
                instance = Activator.CreateInstance(message.ViewModelType,Shell.events);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            foreach (var item in Shell.Items)
            {
                if (item.ToString().Contains(message.ViewModelType.ToString()))
                    instance = item;
            }
            ActivateItem(instance);
          
    }
