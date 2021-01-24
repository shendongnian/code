        log4net.Appender.ForwardingAppender direct; // Global variable to enable threshold change
        public Form1()
        {
            InitializeComponent();
            // configuring Log4net
            log4net.Appender.RollingFileAppender roller = new log4net.Appender.RollingFileAppender();
            roller.AppendToFile = true;
            roller.File = "TestLog.log";
            roller.MaxSizeRollBackups = 10;
            roller.DatePattern = "yyyyMMdd";
            roller.Layout = new log4net.Layout.PatternLayout("%date  %-5level  - %message%newline%exception");
            roller.RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Date;
            roller.StaticLogFileName = true;
            roller.ActivateOptions();
            //log4net.Config.BasicConfigurator.Configure(roller); Do not activate logger, otherwise you will have all events twice
            direct = new log4net.Appender.ForwardingAppender();
            direct.Name = "direct";
            direct.Threshold = log4net.Core.Level.Warn;
            direct.AddAppender(roller);
            direct.ActivateOptions();
            log4net.Config.BasicConfigurator.Configure(direct);
            log4net.Appender.BufferingForwardingAppender buffer = new log4net.Appender.BufferingForwardingAppender();
            buffer.Name = "Buffer";
            buffer.BufferSize = 50;
            buffer.Lossy = true;
            buffer.Evaluator = new log4net.Core.LevelEvaluator(log4net.Core.Level.Error);
            buffer.AddAppender(roller);
            buffer.ActivateOptions();
            log4net.Config.BasicConfigurator.Configure(buffer);
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
                direct.Threshold = log4net.Core.Level.Debug;
            if (numericUpDown1.Value == 1)
                direct.Threshold = log4net.Core.Level.Info;
            if (numericUpDown1.Value == 2)
                direct.Threshold = log4net.Core.Level.Warn;
            if (numericUpDown1.Value == 3)
                direct.Threshold = log4net.Core.Level.Error;
        }
