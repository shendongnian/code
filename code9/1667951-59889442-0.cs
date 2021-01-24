    using Microsoft.Extensions.DependencyInjection;  // provides DI
    using Something; // implements ISomeThing and SomeThing class 
    /*Program.cs */ 
    public static class Program
    {
      //..
      public static IServiceProvider ServiceProvider { get; set; }
      static void ConfigureServices()
      {
        var services = new ServiceCollection();
        services.AddTransient<ISomeThing, SomeThing>();
        ServiceProvider = services.BuildServiceProvider();
      }
      [STAThread]
      static void Main()
      {  
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        ConfigureServices();
        Application.Run(new MainForm());
      }
    }
