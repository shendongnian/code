    [Serializable]
    public abstract class LUISDialogClass : LuisDialog<object>
    {
        public LUISDialogClass(params ILuisService[] services) : base(services)
        {
        }
        [LuisIntent("A")]
        public async Task A(IDialogContext context, LuisResult result)
        {
        }
        [LuisIntent("B")]
        public async Task B(IDialogContext context, LuisResult result)
        {
        }
    }
