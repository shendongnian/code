    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Automation;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process[] procsChrome = Process.GetProcessesByName("chrome");
                if (procsChrome.Length <= 0)
                {
                    Console.WriteLine("Chrome is not running");
                }
                else
                {
                    foreach (Process proc in procsChrome)
                    {
                        // the chrome process must have a window 
                        if (proc.MainWindowHandle == IntPtr.Zero)
                        {
                            continue;
                        }
                        // to find the tabs we first need to locate something reliable - the 'New Tab' button 
                        AutomationElement root = AutomationElement.FromHandle(proc.MainWindowHandle);
                        Condition condTabs = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button);
                        //Condition condNewTab = new PropertyCondition(AutomationElement.NameProperty, "new tab");
                        AutomationElementCollection col = root.FindAll(TreeScope.Descendants, condTabs);
                        AutomationElement elmNewTab = col[4]; // allways the position 4 is new tab button
                        // get the tabstrip by getting the parent of the 'new tab' button 
                        TreeWalker treewalker = TreeWalker.ControlViewWalker;
                        AutomationElement elmTabStrip = treewalker.GetParent(elmNewTab); // <- Error on this line
                       // loop through all the tabs and get the names which is the page title 
                        Condition condTabItem = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem);
                        foreach (AutomationElement tabitem in elmTabStrip.FindAll(TreeScope.Children, condTabItem))
                            {
                                Console.WriteLine(tabitem.Current.Name);
                            }
    
                        }
                    }
                }
            }
        }
    }
