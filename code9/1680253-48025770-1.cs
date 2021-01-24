    [Test]
    public async Task NewSurvey_SendObjectWithOnlyDate_StaticSurveyResourceIdAndDateSet()
    {
        var mvmTest = new TesterPage();
        mvmTest.NewSurveyCommand.Execute(null);
        // Use Reflection to wait for the task
        (GetInstanceField(typeof(TesterPage), mvmTest, "runningTask") as Task).Wait();
        Assert.That(mvmTest.setter, Is.EqualTo(3));
    }
    // A helper method to simplify Reflection
    internal static object GetInstanceField(Type type, object instance, string fieldName)
    {
        BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
        | BindingFlags.Static;
        FieldInfo field = type.GetField(fieldName, bindFlags);
        return field.GetValue(instance);
    }
    public partial class TesterPage : ContentPage
    {
        public int setter = 0;
        private Task runningTask; // The field our Task object is saved in
        public TesterPage ()
        {
            InitializeComponent ();
            NewSurveyCommand = new Command(async () => await (runningTask = NewSurvey()));
        }
        public ICommand NewSurveyCommand { get; private set; }
        public async Task NewSurvey()
        {
            await PostNewSurvey();
        }
        private async Task PostNewSurvey()
        {
            var response = await Another();
            SetSurveyContext(response);
        }
        private async Task<int> Another()
        {
            await Task.Run(() => Task.Delay(1000));
            return 3;
        }
        private void SetSurveyContext(int x)
        {
            setter = x;
        }
    }
