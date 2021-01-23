            private void ReceiveMessage(EnumViewModelNames viewName)
            {
            var selectedViewModel = ViewModelList.Where(x => x.ViewModelName == viewName).SingleOrDefault();
            if (selectedViewModel is TemplateWindowsViewModel)
            {
                TitleChildWindows = (selectedViewModel as TemplateWindowsViewModel).Title;
                OpenChildWindows = true;
                CurrentWindowsViewModel = (selectedViewModel as TemplateWindowsViewModel);
            }
            else if (selectedViewModel != null)
            {
                CurrentViewModel = selectedViewModel;
            }
            Messenger.Default.Unregister<EnumViewModelNames>(this, (action) => ReceiveMessage(action));
            }
