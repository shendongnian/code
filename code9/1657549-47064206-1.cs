    public partial class CurrentTasks : ContentPage
    {
     
    ....
    ....
    ....
    ....
    
        private void Button_Clicked(object sender, EventArgs e)
        {
            CurrentTask newtask = new CurrentTask { TaskName = "New task", TaskDescription = "New task Descroipti", Prioity = ImageSource.FromResource("LifeManager.Images.high.png") };
            currentTaskList.Add(newtask);
    
    
    	   //update Here when task is done
           //Access the main window
    	   var mainWin = Application.Current.Windows
                    .Cast<Window>()
                    .FirstOrDefault(window => window is MainWindow) as MainWindow;
    
            mainWin.completedTask.CompletedTaskList.Add(newtask);
        }
    }
