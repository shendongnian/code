    using Beckhoff.App.Ads.Core.Plc;
    Class test()
    {
    private static IBAAdsServer AdsServer;
    private static IBAAdsCncClient _cncClient;
    public test(IBAAdsServer _adsServer)                  //constructor
    {
        try
        {
            AdsServer = _adsServer;
            _cncClient = AdsServer.GetAdsClient<IBAAdsCncClient>("CNC");
            _cncClient.Synchronize = true;
            Classtocall newClass = ClasstoCall(_cncClient);//Passing the argument directly
    }
    catch (Exception Except)
        { MessageBox.Show("Error ! " + Except.Message); }
    }
