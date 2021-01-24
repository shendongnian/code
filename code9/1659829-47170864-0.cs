    public partial class Form1 : Form
    {
        private String input;
        
        private enum InputMode {
          None,
          Numbers
        }
        
        private class ModeDefinition{
          public InputMode Mode {get; private set; }
          public string Prompt{get; private set; }
          public Action ActionMethod{get; private set; }
    
          public ModeDefinition(InputMode mode, string prompt, Action actionMethod)
          {
              this.Mode = mode;
              this.Prompt = prompt;
              this.ActionMethod = actionMethod;
          }
        }
        
        private InputMode currentMode;
        
        private Dictionary<InputMode,ModeDefinition> modeDefinitions;
    
        public Form1()
        {
            InitializeComponent();
            outbox.AppendText("Hello World!"); //outbox is the display
            
            initialise();
            
            currentMode = InputMode.Numbers;
            commenceAction(modeDefinitions[currentMode]);
            
        }
        
        private void initialise(){
    
          modeDefinitions = new Dictionary<InputMode,ModeDefinition>();
    
          var def1 = new ModeDefinition(InputMode.Numbers, "Enter one, two, three or four.", numbersAction);
          modeDefinitions.Add(InputMode.Numbers, def1);
    
        }
        
        private void commenceAction(ModeDefinition modeDefinition){
          outbox.AppendText(modeDefinition.Prompt);
        }
    
        private void inbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                input = inbox.Text; //inbox is the textbox for input;
                
                var currentMode = modeDefinitions[currentMode];
                
                // Execute the mode action
                currentMode.ActionMethod();
            }
            else
            {
                //do nothing
            }
        }
        
        private void numbersAction(){
        
            if (text_input.Equals("one"))
            {
               outbox.AppendText("Sunflowers");
            }
            else if (text_input.Equals("two))
            {
               outbox.AppendText("Tulips");
            }
            else if (text_input.Equals("three"))
            {
               outbox.AppendText("Daisies");
            }
            else if (text_input.Equals("four"))
            {
               outbox.AppendText("Poppies");
            }
            else if (text_input.Equals("quit"))
            {
               Application.Exit();
            }
            else
            {
               outbox.AppendText("Try again.");
    
              var currentMode = modeDefinitions[currentMode];
              outbox.AppendText(modeDefinition.Prompt);          
            }
        }
    }
