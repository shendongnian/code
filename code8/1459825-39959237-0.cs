    using NUnit.Framework;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows;
    using System.Windows.Automation.Peers;
    using System.Windows.Automation.Provider;
    using System.Windows.Controls;
    namespace InvokeTest
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
        public class MainWindowViewModel
        {
            string textfield;
            public string TextProperty
            {
                get { DebugLog("getter"); return textfield; }
                set { textfield = value; DebugLog("setter"); }
            }
            private void DebugLog(string function)
            {
                Debug.WriteLine(ToString() + " " + nameof(TextProperty) + " " + function + " was called. value: '" + textfield ?? "<null>" + "'");
            }
            [TestFixture, Apartment(ApartmentState.STA)]
            public class WPFTest
            {
                MainWindow view;
                MainWindowViewModel viewmodel;
                [SetUp]
                public void SetUp()
                {
                    view = new MainWindow();
                    viewmodel = new MainWindowViewModel();
                    view.DataContext = viewmodel;
                    view.Show();
                }
                [TearDown]
                public void TearDown()
                {
                    view.Close();
                    view.DataContext = null;
                    view = null;
                    viewmodel = null;
                }
                [Test]
                public void SetTextBox_NoAutomation()
                {
                    string expected = "I want to set this";
                    view.MyTextBox.Text = expected;
                    Assert.AreEqual(expected, viewmodel.TextProperty);
                }
                [Test]
                public void SetTextBox_UIAutomation()
                {
                    string expected = "I want to set this";
                    SetValue(view.MyTextBox, expected);
                    Assert.AreEqual(expected, viewmodel.TextProperty);
                }
                private void SetValue(TextBox textbox, string value)
                {
                    TextBoxAutomationPeer peer = new TextBoxAutomationPeer(textbox);
                    IValueProvider provider = peer.GetPattern(PatternInterface.Value) as IValueProvider;
                    provider.SetValue(value);
                }
            }
        }
    }
