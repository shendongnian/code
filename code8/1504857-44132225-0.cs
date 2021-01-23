    {
      "dependencies": {
        "BundlerMinifier.Core": "2.4.337",
        "Microsoft.ApplicationInsights.AspNetCore": "2.0.0",
        "Microsoft.AspNetCore.Diagnostics": "1.1.2",
        "Microsoft.AspNetCore.Mvc": "1.1.3",
        "Microsoft.AspNetCore.Mvc.TagHelpers": "1.1.3",
        "Microsoft.AspNetCore.Razor.Design": "1.1.0-preview4-final",
        "Microsoft.AspNetCore.Razor.Tools": "1.1.0-preview4-final",
        "Microsoft.AspNetCore.Routing": "1.1.2",
        "Microsoft.AspNetCore.Server.IISIntegration": "1.1.2",
        "Microsoft.AspNetCore.Server.IISIntegration.Tools": "1.1.0-preview4-final",
        "Microsoft.AspNetCore.Server.Kestrel": "1.1.2",
        "Microsoft.AspNetCore.StaticFiles": "1.1.2",
        "Microsoft.Extensions.Configuration.EnvironmentVariables": "1.1.2",
        "Microsoft.Extensions.Configuration.Json": "1.1.2",
        "Microsoft.Extensions.Logging": "1.1.2",
        "Microsoft.Extensions.Logging.Console": "1.1.2",
        "Microsoft.Extensions.Logging.Debug": "1.1.2",
        "Microsoft.NETCore.App": {
          "type": "platform",
          "version": "1.1.1"
        },
        "Microsoft.VisualStudio.Web.BrowserLink.Loader": "14.1.0",
        //"Microsoft.VisualStudio.Web.CodeGeneration.Tools": "1.1.0-preview4-final",
        //"Microsoft.VisualStudio.Web.CodeGenerators.Mvc": "1.1.1",
        "Wallet.Core": "1.0.0-*"
      },
    
      "tools": {
        "Microsoft.AspNetCore.Razor.Tools": "1.1.0-preview4-final"
      },
    
      "frameworks": {
        "netcoreapp1.1": {
          "imports": [
            "dnxcore50"
          ]
        }
      },
    
      "buildOptions": {
        "emitEntryPoint": true,
        "preserveCompilationContext": true
      },
    
      "runtimeOptions": {
        "configProperties": {
          "System.GC.Server": true
        }
      },
    
      "publishOptions": {
        "include": [
          "wwwroot",
          "**/*.cshtml",
          "appsettings.json",
          "web.config"
        ]
      },
    
      "scripts": {
        "prepublish": [ "bower install", "dotnet bundle" ],
        "postpublish": [ "dotnet publish-iis --publish-folder %publish:OutputPath% --framework %publish:FullTargetFramework%" ]
      }
    }
