    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using System.Threading;
    using System.Runtime.CompilerServices;
    using System.IO;
    
    namespace asyncpackagetest
    {
        [ProvideService((typeof(STextWriterService)), IsAsyncQueryable = true)]
        [ProvideAutoLoad(VSConstants.UICONTEXT.NoSolution_string, PackageAutoLoadFlags.BackgroundLoad)]
        [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
        [Guid(VSPackage1.PackageGuidString)]
        public sealed class VSPackage1 : AsyncPackage
        {
    
            public const string PackageGuidString = "3dc186f8-2146-4d89-ac33-e216b3ead526";
    
            public VSPackage1()
            {
    
            }
    
            protected override async System.Threading.Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
            {
                this.AddService(typeof(STextWriterService), CreateService);
                await base.InitializeAsync(cancellationToken, progress);
                ITextWriterService textService = await this.GetServiceAsync(typeof(STextWriterService)) as ITextWriterService;
                await textService.WriteLineAsync(@"c:\windows\temp\async_service.txt", "this is a test");
                
            }
    
            public async System.Threading.Tasks.Task<object> CreateService(IAsyncServiceContainer container, CancellationToken cancellationToken, Type serviceType)
            {
                STextWriterService service = null;
                await System.Threading.Tasks.Task.Run(() => {
                    service = new TextWriterService(this);
                });
    
                return service;
            }
    
            public class TextWriterService : STextWriterService, ITextWriterService
            {
                private Microsoft.VisualStudio.Shell.IAsyncServiceProvider serviceProvider;
                public TextWriterService(Microsoft.VisualStudio.Shell.IAsyncServiceProvider provider)
                {
                    serviceProvider = provider;
                }
                public async System.Threading.Tasks.Task WriteLineAsync(string path, string line)
                {
                    StreamWriter writer = new StreamWriter(path);
                    await writer.WriteLineAsync(line);
                    writer.Close();
                }
                public TaskAwaiter GetAwaiter()
                {
                    return new TaskAwaiter();
                }
            }
            public interface STextWriterService
            {
            }
            public interface ITextWriterService
            {
                System.Threading.Tasks.Task WriteLineAsync(string path, string line);
                TaskAwaiter GetAwaiter();
            }
        }
    }
