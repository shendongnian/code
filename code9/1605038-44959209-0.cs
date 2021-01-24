    private ConcurrentDictionary<Twain,Form> m_References = new ConcurrentDictionary<Twain,Form>();
    
    
    private void ScanThread()
    {
        // Instantiate the Twain object and hookup event handlers
        Form frm = new Form();
        Twain twain = new Twain(new WinFormsWindowMessageHook(frm));
        m_References.Add(twain, frm);
    
        twain.TransferImage += Twain_TransferImage;
        twain.ScanningComplete += Twain_ScanningComplete;
    
        // Start the scanning process by passing along pre-defined scan settings
        twain.StartScanning(GetScanSettings());
    }
    
    
    private void Twain_ScanningComplete(object sender, ScanningCompleteEventArgs args)
    {
        Form frm;
        m_References.TryRemove((Twain) sender, out frm);
        if(null != frm)
        {
           frm.Close();
        }
    }
