        ObservableCollection<Tasks> TaskList;
        private async Task GetData(long id)
        {
            List<Tasks> tasks = await ApiManager.GetTasksFromListAsync(id);
 
            TaskList = new ObservableCollection<Tasks>(tasks);
            lvwDetailPage.ItemsSource = TaskList;
 
            lvwDetailPage.ItemSelected += LvwDetailPage_ItemSelected;
        }
        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            Tasks task = (sender as Switch).BindingContext as Tasks;
            // assuming TaskList is an ObservableCollection<Task> that is
            // your List's ItemsSoruce
            TaskList.Remove(task);
            await ApiManager.UpdateTasksFromListAsync(task);
        }
