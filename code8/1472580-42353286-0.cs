    namespace Core
    {
        public class App : MvxApplication
        {
            public override void Initialize()
            {
                CreatableTypes()
                    .EndingWith("Service")
                    .AsInterfaces()
                    .RegisterAsLazySingleton();
    
              
                RegisterAppStart<ViewModels.FirstViewModel>();
