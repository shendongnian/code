    public sealed class TriggerDownload : NativeActivity<string>
    {
        [RequiredArgument]
        public InArgument<string> BookmarkName { get; set; }
        protected override void Execute(NativeActivityContext context)
        {
            // Create a Bookmark and wait for it to be resumed.
            context.CreateBookmark(BookmarkName.Get(context),
                new BookmarkCallback(OnResumeBookmark));
        }
        protected override bool CanInduceIdle
        {
            get { return true; }
        }
        public void OnResumeBookmark(NativeActivityContext context, Bookmark bookmark, object obj)
        {
           // When the Bookmark is resumed, assign its value to
           // the Result argument. (This depends on whether you have a result on your GetData method like a string with a result code or something)
           Result.Set(context, (string)obj);
        }
    }
