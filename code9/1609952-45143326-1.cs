    public class MyPlugin : IPlugin {
         public void Do(IMyApplicationContext context) { 
             context.SomeService.DoAThing();
             System.Windows.MessageBox.Show(context.SomeData);
         }
    }
