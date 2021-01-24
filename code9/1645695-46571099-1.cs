    // Other namespaces (essential)
    ...
    
    // Required namespaces for this process
    using Windows.UI.Popups;
    using System.Runtime.InteropServices;
    
    namespace PopupMessageApp
    {
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
            }
    
            // I will only comment those that are not obvious to comprehend.
            private async void ShowMessage(string title, string content, [Optional] object[][] buttons)
            {
                MessageDialog dialog = new MessageDialog(content, title);
    
                // Sets the default cancel and default indexes to zero. (incase no buttons are passed)
                dialog.CancelCommandIndex   = 0;
                dialog.DefaultCommandIndex  = 0;
    
                // If the optional buttons array is not empty or null.
                if (buttons != null)
                {
                    // If there's multiple buttons
                    if (buttons.Length > 1)
                    {
                        // Loops through the given buttons array
                        for (Int32 i = 0; i < buttons.Length; i++)
                        {
                            /* Assigns text and handler variables from the current index subarray.
                             * The first object at the currentindex should be a string and 
                             * the second object should be a "UICommandInvokedHandler" 
                             */
                            string text = (string)buttons[i][0];
    
                            UICommandInvokedHandler handler = (UICommandInvokedHandler)buttons[i][1];
    
                            /* Checks whether both variables types actually are relevant and correct.
                             * If not, it will return and terminate this function and not display anything.
                             */
                            if (handler.GetType().Equals(typeof(UICommandInvokedHandler)) &&
                                text.GetType().Equals(typeof(string)))
                            {
                                /* Creates a new "UICommand" instance which is required for
                                 * adding multiple buttons.
                                 */
                                UICommand button = new UICommand(text, handler);
    
                                // Simply adds the newly created button to the dialog
                                dialog.Commands.Add(button);
                            }
                            else return;
                        }
                    }
                    else
                    {
                        // Already described
                        string text = (string)buttons[0][0];
    
                        UICommandInvokedHandler handler = (UICommandInvokedHandler)buttons[0][1];
    
                        // Already described
                        if (handler.GetType().Equals(typeof(UICommandInvokedHandler)) &&
                            text.GetType().Equals(typeof(string)))
                        {
                            // Already described
                            UICommand button = new UICommand(text, handler);
    
                            // Already described
                            dialog.Commands.Add(button);
                        }
                        else return;
                    }
    
                    /* Sets the default command index to the length of the button array.
                     * The first, colored button will become the default button or index.
                     */
                    dialog.DefaultCommandIndex = (UInt32)buttons.Length;
                }
    
                await dialog.ShowAsync();
            }
    
            private async void MainPage_Load(object sender, EventArgs e)
            {
                /* Single object arrays with a string object and a "UICommandInvokedHandler" handler.
                 * The ShowMessage function will only use the first and second index of these arrays.
                 * Replace the "return" statement with a function or whatever you desire.
                 * (The "return" statemnet will just return and do nothing (obviously))
                 */
                object[] button_one = { "Yes", new UICommandInvokedHandler((e) => { return; }) };
                object[] button_two = { "No", new UICommandInvokedHandler((e) => { return; }) };
    
                /* Object arrays within an object array.
                 * The first index in this array will become the first button in the following message.
                 * The first button will also get a different color and will become the default index.
                 * For instance, if you press on the "enter" key, it will press on the first button.
                 * You can add as many buttons as the "Windows.UI.Popups.MessageDialog" wants you to.
                 */
                object[][] buttons = new object[][]
                {
                    button_one,
                    button_two
                };
    
                // Displays a popup message with multiple buttons
                ShowMessage("Title", "Content here", buttons);
    
                /* Displays a popup message without multiple buttons.
                 * The last argument of the ShowMessage function is optional.
                 * because of the definition of the namespace "System.Runtime.InteropServices".
                 */
                ShowMessage("Title", "Content here");
    
                // PS, I have a life, just trying to get points xD // BluDay
            }
        }
    }
