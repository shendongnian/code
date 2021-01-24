    namespace TWToolbar
    {
        using System;
        using System.Runtime.InteropServices;
        using Microsoft.VisualStudio.Shell;
        using System.ComponentModel.Design;
        using System.Collections.Generic;
    
    
        /// <summary>
        /// This class implements the tool window exposed by this package and hosts a user control.
        /// </summary>
        /// <remarks>
        /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
        /// usually implemented by the package implementer.
        /// <para>
        /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
        /// implementation of the IVsUIElementPane interface.
        /// </para>
        /// </remarks>
        [Guid("1a24c96c-30bd-466b-8315-14bf54e4f17a")]
        public class TestToolWindow : ToolWindowPane
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TestToolWindow"/> class.
            /// </summary>
            /// 
            public UserControl1 control;
            public TestToolWindow() : base(null)
            {
                this.Caption = "TestToolWindow";
             // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
                // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
                // the object returned by the Content property.
                this.control = new UserControl1();//new TestToolWindowControl(users);
           }
    
            override public System.Windows.Forms.IWin32Window Window
            {
                get
                {
                    return (System.Windows.Forms.IWin32Window)control;
                }
            }
        }
    }
