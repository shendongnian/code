       public class ControlViewModel
       {
          public Collection<CommandViewModel> Commands { get; }
    
          public ControlViewModel()
          {
               // Here have logic to determine which commands are added to the collection
             var command1 = new RelayCommand(p => ActionForButton1());
             var command2 = new RelayCommand(p => ActionForButton2());
    
             Commands = new Collection<CommandViewModel>();
             Commands.Add(new CommandViewModel(command1, "Button 1"));
             Commands.Add(new CommandViewModel(command2, "Button 2"));
             
          }
    
          private void ActionForButton1()
          {
             // ....
          }
    
          private void ActionForButton2()
          {
             // ....
          }
       }
