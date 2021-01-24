    using Microsoft.Extensions.Options;
    using NLog;
    using NLog.AWS.Logger;
    using NLog.Config;
    using NLog.Layouts;
    using System;
    
    namespace AAAA.BBBB.CCCC
    {
        public interface ILogger
        {
            void LogError(string message);
            void LogError(string message, Exception exception);
            void LogInformation(string message);
        }
    
        public class Logger : ILogger
        {
            private static readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();
    
            public Logger(IOptions<AppSettings> appSettings)
            {
                var awsSettings = appSettings.Value.AwsSettings;
    
                var awsTarget = new AWSTarget()
                {
                    LogGroup = awsSettings.CloudWatchLogGroup,
                    Region = awsSettings.Region,
                    Credentials = new Amazon.Runtime.BasicAWSCredentials(awsSettings.AccessId, awsSettings.AccessKey),
                    Layout = new SimpleLayout
                    {
                        Text = "${longdate} ${level:uppercase=true} ${machinename} ${message} ${exception:format=tostring}"
                    }
                };
    
                var config = new LoggingConfiguration();
                config.AddTarget("aws", awsTarget);
                config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, awsTarget));
                LogManager.Configuration = config;
            }
    
            public void LogError(string message)
            {
                _logger.Error(message);
            }
    
            public void LogError(string message, Exception exception)
            {
                _logger.Error(exception, message);
            }
    
            public void LogInformation(string message)
            {
                _logger.Info(message);
            }
        }
        public class AppSettings
        {
            public AwsSettings AwsSettings { get; set; }
        }
        public class AwsSettings
        {
            public string AccessId { get; set; } = default!;
            public string AccessKey { get; set; } = default!;
            public string CloudWatchLogGroup { get; set; } = default!;
            public string Region { get; set; } = default!;
        }
    }
