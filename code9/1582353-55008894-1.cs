    using System;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.Win32;
    using Task = System.Threading.Tasks.Task;
    
    namespace VSIXProject
    {
        /// <summary>
        /// This is the class that implements the package exposed by this assembly.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The minimum requirement for a class to be considered a valid package for Visual Studio
        /// is to implement the IVsPackage interface and register itself with the shell.
        /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
        /// to do it: it derives from the Package class that provides the implementation of the
        /// IVsPackage interface and uses the registration attributes defined in the framework to
        /// register itself and its components with the shell. These attributes tell the pkgdef creation
        /// utility what data to put into .pkgdef file.
        /// </para>
        /// <para>
        /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
        /// </para>
        /// </remarks>
        [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
        [InstalledProductRegistration("#1110", "#1112", "1.0", IconResourceID = 1400)] // Info on this package for Help/About
        [Guid(VSPackageEvents.PackageGuidString)]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    #pragma warning disable VSSDK004 // Use BackgroundLoad flag in ProvideAutoLoad attribute for asynchronous auto load.
        [ProvideAutoLoad(UIContextGuids80.SolutionExists)]
    #pragma warning restore VSSDK004 // Use BackgroundLoad flag in ProvideAutoLoad attribute for asynchronous auto load.
        public sealed class VSPackageEvents : AsyncPackage
        {
            EnvDTE.DTE dte = null;
            EnvDTE.Events events = null;
            EnvDTE.SolutionEvents solutionEvents = null;
            /// <summary>
            /// VSPackageEvents GUID string. Replace this Guid
            /// </summary>
            public const string PackageGuidString = "12135331-70d8-48bb-abc7-5e5ffc65e041";
    
            /// <summary>
            /// Initializes a new instance of the <see cref="VSPackageEvents"/> class.
            /// </summary>
            public VSPackageEvents()
            {
                // Inside this method you can place any initialization code that does not require
                // any Visual Studio service because at this point the package object is created but
                // not sited yet inside Visual Studio environment. The place to do all the other
                // initialization is the Initialize method.
            }
            private void SolutionEvents_Opened()
            {
    // put your code here after opened event
            }
            private void SolutionEvents_AfterClosing()
            {
    // put your code here after closed event
            }
           
            /// <summary>
            /// Initialization of the package; this method is called right after the package is sited, so this is the place
            /// where you can put all the initialization code that rely on services provided by VisualStudio.
            /// </summary>
            /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
            /// <param name="progress">A provider for progress updates.</param>
            /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
            protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
            {
                // When initialized asynchronously, the current thread may be a background thread at this point.
                // Do any initialization that requires the UI thread after switching to the UI thread.
                await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
                // replace dte from next line with your dte package
                // dte = Utilities.Utility.GetEnvDTE(this);
                events = dte.Events;       
                solutionEvents = events.SolutionEvents;
                solutionEvents.Opened += SolutionEvents_Opened;
                solutionEvents.AfterClosing += SolutionEvents_AfterClosing;
            }    
            
        }
    }
