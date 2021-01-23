    using Foundation;
    using QuickLook;
    using System;
    using System.IO;
    using UIKit;
    using MyApp.Common.Interfaces;
    
    [assembly: Dependency(typeof(DataViewer))]
    namespace MyApp.iOS.Common
    {
        public class DataViewer : IDataViewer
        {
            public void showPhoto(string AttachmentName, byte[] AttachmentBytes)
            {
                var FileName = AttachmentName;
                string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    
                var filename = Path.Combine(dirPath, FileName);
                FileInfo fi = new FileInfo(filename);
    
                if (!NSFileManager.DefaultManager.FileExists(filename))
                {
                    Stream stream = new MemoryStream(AttachmentBytes);
                    NSData imgData = NSData.FromStream(stream);
                    NSError err;
                    imgData.Save(filename, false, out err);
                }
    
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    QLPreviewController previewController = new QLPreviewController();
                    previewController.DataSource = new PDFPreviewControllerDataSource(fi.FullName, fi.Name);
                    UINavigationController controller = FindNavigationController();
                    if (controller != null)
                        controller.PresentViewController(previewController, true, null);
                });
    
            }
    
            private UINavigationController FindNavigationController()
            {
                foreach (var window in UIApplication.SharedApplication.Windows)
                {
                    if (window.RootViewController.NavigationController != null)
                        return window.RootViewController.NavigationController;
                    else
                    {
                        UINavigationController val = CheckSubs(window.RootViewController.ChildViewControllers);
                        if (val != null)
                            return val;
                    }
                }
    
                return null;
            }
    
            private UINavigationController CheckSubs(UIViewController[] controllers)
            {
                foreach (var controller in controllers)
                {
                    if (controller.NavigationController != null)
                        return controller.NavigationController;
                    else
                    {
                        UINavigationController val = CheckSubs(controller.ChildViewControllers);
                        if (val != null)
                            return val;
                    }
                }
                return null;
            }
    
            public string ImageExists(string Filename, byte[] Bytedata)
            {
    
                string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    
                var filename = Path.Combine(dirPath, Filename);
                FileInfo fi = new FileInfo(filename);
    
                if (!NSFileManager.DefaultManager.FileExists(filename))
                {
                    Stream stream = new MemoryStream(Bytedata);
                    NSData imgData = NSData.FromStream(stream);
                    NSError err;
                    imgData.Save(filename, false, out err);
                    return filename;
    
                }
                else
                {
                    return filename;
                }
            }
        }
    
        public class PDFItem : QLPreviewItem
        {
            string title;
            string uri;
    
            public PDFItem(string title, string uri)
            {
                this.title = title;
                this.uri = uri;
            }
    
            public override string ItemTitle
            {
                get { return title; }
            }
    
            public override NSUrl ItemUrl
            {
                get { return NSUrl.FromFilename(uri); }
            }
        }
    
        public class PDFPreviewControllerDataSource : QLPreviewControllerDataSource
        {
            string url = "";
            string filename = "";
    
            public PDFPreviewControllerDataSource(string url, string filename)
            {
                this.url = url;
                this.filename = filename;
            }
    
            public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
            {
                return (IQLPreviewItem)new PDFItem(filename, url);
            }
    
            public override nint PreviewItemCount(QLPreviewController controller)
            {
                return 1;
            }
        }
    }
