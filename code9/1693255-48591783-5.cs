    using Xamarin.Forms;
    
    namespace CustomStepper
    {
        public class App : Application
        {
            public App() => MainPage = new StepperPage();
        }
    
        class StepperPage : ContentPage
        {
            public StepperPage()
            {
                Content = new RedStepper
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
            }
        }
    
        public class RedStepper : Stepper
        {
            
        }
    }
