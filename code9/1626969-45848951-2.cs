    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.Logging.Console;
    using Microsoft.Extensions.Logging.Debug;
    
    namespace WebApplication1
    {
        public class LoggerProviderShim : ILoggerProvider
        {
            private ILoggerProvider baseLoggerProvider;
    
            public LoggerProviderShim(ILoggerProvider baseLoggerProvider)
            {
                this.baseLoggerProvider = baseLoggerProvider;
            }
    
            public ILogger CreateLogger(string categoryName)
            {
                return new LoggerShim(baseLoggerProvider.CreateLogger(categoryName), categoryName);
            }
    
            public void Dispose()
            {
                baseLoggerProvider.Dispose();
            }
        }
    
        public class LoggerShim : ILogger
        {
            private ILogger     baseLogger;
            private bool        treatInfoAsDebug;
    
            public LoggerShim(ILogger baseLogger, string categoryName)
            {
                this.baseLogger       = baseLogger;
                this.treatInfoAsDebug = categoryName != null && categoryName.StartsWith("Microsoft.AspNetCore.");
            }
    
            public IDisposable BeginScope<TState>(TState state)
            {
                return baseLogger.BeginScope(state);
            }
    
            public bool IsEnabled(LogLevel logLevel)
            {
                return baseLogger.IsEnabled(logLevel);
            }
    
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                if (treatInfoAsDebug && logLevel == LogLevel.Information)
                {
                    logLevel = LogLevel.Debug;
                }
    
                baseLogger.Log(logLevel, eventId, state, exception, formatter);
            }
        }
    
        public class Startup
        {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }
    
            public IConfiguration Configuration { get; }
    
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc();
            }
    
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                var debugLogProvider = new DebugLoggerProvider();
    
                loggerFactory.AddProvider(debugLogProvider);
                //loggerFactory.AddProvider(new LoggerProviderShim(debugLogProvider));
    
                app.UseMvc();
            }
        }
    }
