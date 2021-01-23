        I guess your idea to create independent command.cs is to put all the action/command in as separate class. Which looks quite good. So basically you can create a command repository where you can register your all commands.
        
        Let see this with an example:
        
        public static class AppCommandRepository {
         public static ICommand YourCommand { get; private set; }
        // You can also register other command as well.
        internal static void Initialize()
                {
                    YourCommand = new YourCommand();
                   
                }
        }
    
    Now in xaml 
    <Button Command="Commands:AppCommandRepository.YourCommand" CommandParameter="{Binding}" /> !--Here commands is a namespace reference in xaml which is pointing to command repo.
    
    In YourCommand.cs implement the ICommandInterface. Make sure that in overided execute method you pass the parameter of Page1 class. 
    Like this:
    void ICommand.Execute(Page1 parameter).
    
    Now as you have passed the commandParamter from Page1 file, when user hits the button click event then Page1 Reference will come as a parameter to the execute method. Also make sure you initialize you command repository as the entry point of the app. I guess the question that you asked is very broader, there can be multiple implementation for this. 
