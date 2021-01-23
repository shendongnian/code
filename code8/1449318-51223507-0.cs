    using System.Threading.Tasks;
    using System;
    using System.Windows;
    // 1. call method with message window
    ShowMyDialogWindow();
    // 2. use async and await with Task, create your message window here.
    public async void ShowMyDialogWindow()
    {
        MessageBoxResult result= await Task.Run(() => MessageBox.Show("Arre you happy?", 
            "My window name", MessageBoxButton.YesNoCancel));
            switch (result)
            {
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.Yes:
                    // do something
                    break;
                case MessageBoxResult.No:
                    // do something
                    break;
                default:
                    break;
            }
        // This line will be executed after windows closed you can use it for 
        // something (close resource, stop timer ...)
        DoSomeThingHereToo();
    }
    
    // message window do not block your app, app will running other task.
 
