    // 1
    namespace Japanese.Views.Phrases
    {
        public partial class PhrasesPage : ContentPage
        {
            PhrasesFrame phrasesFrame = new PhrasesFrame();
    // 2
    namespace Japanese.Views.Phrases
    {
        public partial class PhrasesPage
        {
            public void setTimeInterval()
            {
                phrasesFrame // CAN access
