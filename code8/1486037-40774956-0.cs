    public class Image {
        (...)
        public ChapterPageViewModel ViewModel { get; set; }
    }
    
    public class ChapterPageViewModel
    {
        (...)
        private async void Initialize() {
            pageList = await ComicChapterGet.GetAsync(_chapterId);
            foreach(Image img in pageList)
                img.ViewModel = this;
        }
    }
