    using System.Threading.Tasks;
    
    namespace TestMe
    {
        using NiHaoRS; // TODO: Rename namespaces to TestMe
        
        public class LinuxClipboard
            : GenericClipboard
    
        {
    
            public LinuxClipboard()
            { }
            
            
            public static async Task TestClipboard()
            {
                GenericClipboard lc = new LinuxClipboard();
                await lc.SetClipboardContentsAsync("Hello KLIPPY");
                string cc = await lc.GetClipboardContentAsync();
                System.Console.WriteLine(cc);
            } // End Sub TestClipboard 
            
            
            public override async Task SetClipboardContentsAsync(string text)
            {
                Tmds.DBus.ObjectPath objectPath = new Tmds.DBus.ObjectPath("/klipper");
                string service = "org.kde.klipper";
    
                using (Tmds.DBus.Connection connection = new Tmds.DBus.Connection(Tmds.DBus.Address.Session))
                {
                    await connection.ConnectAsync();
    
                    Klipper.DBus.IKlipper klipper = connection.CreateProxy<Klipper.DBus.IKlipper>(service, objectPath);
                    await klipper.setClipboardContentsAsync(text);
                } // End using connection 
    
            } // End Task SetClipboardContentsAsync 
            
            
            public override async Task<string> GetClipboardContentAsync()
            {
                string clipboardContents = null;
    
                Tmds.DBus.ObjectPath objectPath = new Tmds.DBus.ObjectPath("/klipper");
                string service = "org.kde.klipper";
    
                using (Tmds.DBus.Connection connection = new Tmds.DBus.Connection(Tmds.DBus.Address.Session))
                {
                    await connection.ConnectAsync();
    
                    Klipper.DBus.IKlipper klipper = connection.CreateProxy<Klipper.DBus.IKlipper>(service, objectPath);
    
                    clipboardContents = await klipper.getClipboardContentsAsync();
                } // End Using connection 
    
                return clipboardContents;
            } // End Task GetClipboardContentsAsync 
            
            
        } // End Class LinuxClipBoardAPI 
        
        
    } // End Namespace TestMe
