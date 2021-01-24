    using _ = SamplePage;
    public class SamplePage : Page<SamplePage>
    {
        public Link<_> Save1 { get; private set; }
        
        public LinkDelegate<_> Save2 { get; private set; }
        
        public Link<SamplePage2, _> Navigate1 { get; private set; }
        
        public LinkDelegate<SamplePage2, _> Navigate2 { get; private set; }
    }
