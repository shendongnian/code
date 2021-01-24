    public partial class Form1 : Form
    {
        private static Logger logger = LogManager.GetLogger(typeof(Main).Name);
        private MyClass instance =new MyClass();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SetupFormLogger();
            logger.Info("Some message"); // this message appears in the richtextbox log
        }
        public void SetupFormLogger()
        {
            NLog.Windows.Forms.RichTextBoxTarget target = new NLog.Windows.Forms.RichTextBoxTarget();
            target.Name = "control";
            target.Layout = "${longdate} ${level:uppercase=true} ${logger} ${message}";
            target.ControlName = richTextBox1.Name;
            target.FormName = this.Name;
            target.TargetForm = this;
            target.AutoScroll = true;
            target.MaxLines = 10000;
            target.UseDefaultRowColoringRules = false;
            target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Trace", "WhiteSmoke", "Black", FontStyle.Regular));
            target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Debug", "Gray", "Black"));
            target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Info", "WhiteSmoke", "Black"));
            target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Warn", "DarkRed", "Black"));
            target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Error", "White", "DarkRed", FontStyle.Bold));
            target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Fatal", "Yellow", "DarkRed", FontStyle.Bold));
            AsyncTargetWrapper asyncWrapper = new AsyncTargetWrapper();
            asyncWrapper.Name = "AsyncRichTextBox";
            asyncWrapper.WrappedTarget = target;
            SimpleConfigurator.ConfigureForTargetLogging(asyncWrapper, LogLevel.Debug);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            instance.Test();
        }
    }
    class MyClass
    {
        public void Test()
        {
            Logger log = LogManager.GetLogger(typeof(MyClass).Name);
            log.Info("Text");  // THIS TEXT IS NOT LOGGED OR DISPLAYED IN RICHTEXTBOX
        }
    }
