    using System;
    using interop.UIAutomationCore;
    
    namespace PrintDesktopUiaElementNameViaCom
    {
        class PrintDesktopUiaElementNameViaComProgram
        {
            static void Main(string[] args)
            {
                // Instantiate the UIA object:
                IUIAutomation _automation = new CUIAutomation();
                // Get the root element
                IUIAutomationElement rootElement = _automation.GetRootElement();
                // Get its name
                string rootName = rootElement.CurrentName;
                Console.WriteLine(
                    "The root automation element's name should be 'Desktop'.");
                Console.WriteLine("The actual value is: '{0}'", rootName);
            }
        }
    }
