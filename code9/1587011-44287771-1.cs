    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using BF = System.Reflection.BindingFlags;
    
    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                btn1.Click += (s, e) => Console.WriteLine($"{((Button)s).Content}a pressed");
                btn1.Click += Btn1_Click;
                btn1.MouseEnter += (s, e) => Console.WriteLine($"{((Button)s).Content} mouse entered");
    
                AddButton();
            }
    
            private void Btn1_Click(object sender, RoutedEventArgs e)
            {
                Console.WriteLine($"{((Button)sender).Content}b pressed");
            }
    
    
            private void AddButton()
            {
                Button btn2 = new Button() { Content = "Button 02" };
                panel.Children.Add(btn2);
    
                // Copy all event handler from btn1 to btn2 ??
                FieldInfo[] fields = btn1.GetType().GetFields(BF.Static | BF.NonPublic | BF.Instance | BF.Public | BF.FlattenHierarchy);
                foreach (FieldInfo field in fields.Where(x => x.FieldType == typeof(RoutedEvent)))
                {
                    RoutedEventHandlerInfo[] routedEventHandlerInfos = GetRoutedEventHandlers(btn1, (RoutedEvent)field.GetValue(btn1));
                    if (routedEventHandlerInfos != null)
                    {
                        foreach (RoutedEventHandlerInfo routedEventHandlerInfo in routedEventHandlerInfos)
                            btn2.AddHandler((RoutedEvent)field.GetValue(btn1), routedEventHandlerInfo.Handler);
                    }
                }
            }
    
    
            /// <summary>
            /// Get a list of RoutedEventHandlers
            /// Credit: Douglas : https://stackoverflow.com/a/12618521/3971575
            /// </summary>
            /// <param name="element"></param>
            /// <param name="routedEvent"></param>
            /// <returns></returns>
            public RoutedEventHandlerInfo[] GetRoutedEventHandlers(UIElement element, RoutedEvent routedEvent)
            {
                // Get the EventHandlersStore instance which holds event handlers for the specified element.
                // The EventHandlersStore class is declared as internal.
                PropertyInfo eventHandlersStoreProperty = typeof(UIElement).GetProperty("EventHandlersStore", BF.Instance | BF.NonPublic);
                object eventHandlersStore = eventHandlersStoreProperty.GetValue(element, null);
    
                // If no event handlers are subscribed, eventHandlersStore will be null.
                // Credit: https://stackoverflow.com/a/16392387/1149773
                if (eventHandlersStore == null)
                    return null;
    
                // Invoke the GetRoutedEventHandlers method on the EventHandlersStore instance 
                // for getting an array of the subscribed event handlers.
                MethodInfo getRoutedEventHandlers = eventHandlersStore.GetType().GetMethod("GetRoutedEventHandlers", BF.Instance | BF.Public | BF.NonPublic);
    
                return (RoutedEventHandlerInfo[])getRoutedEventHandlers.Invoke(eventHandlersStore, new object[] { routedEvent });
            }
    
        }
    }
