    using EnvDTE;
    using EnvDTE80;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace Company.VSPackageHW2
    {
        /// <summary>
        /// Interaction logic for MyControl.xaml
        /// </summary>
        public partial class MyControl : UserControl,IVsDebuggerEvents
        {
            public static VSPackageHW2Package package;
            readonly IVsDebugger _debugger;
            readonly DTE _dte;
            readonly Debugger2 _dteDebugger;
            readonly uint _debuggerEventsCookie;
    
            public MyControl()
            {
                InitializeComponent();
    
                var packageServiceProvider = (IServiceProvider)package;
                _debugger = packageServiceProvider.GetService(typeof(SVsShellDebugger)) as IVsDebugger;
                _dte = packageServiceProvider.GetService(typeof(SDTE)) as DTE;
    
                if (_debugger.AdviseDebuggerEvents(this, out _debuggerEventsCookie) != VSConstants.S_OK)
                {
                    MessageBox.Show("DebugManager setup failed");
                }
                else 
                {
                    MessageBox.Show("ok");
                }
            }
    
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
    
            
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
    
                MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentUICulture, "We are inside {0}.button1_Click()", this.ToString()),
                                "lzyToolWindow");
    
            }
    
            public int OnModeChange(DBGMODE dbgmodeNew)
            {
                MessageBox.Show("debug mode change");
                throw new NotImplementedException();
            }
        }
    }
