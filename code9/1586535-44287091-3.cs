    public class MyController
    {
        public MyController() : this( 
            new StreamLoader( @"\\pc030\TemporaryPDF\" ),
            new AzureStreamRepository( StorageAccount, UploaderStorage.Container ) )
        {}
    }
