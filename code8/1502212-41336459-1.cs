    {
      "dependencies": {
        "Moq": "4.6.38-alpha",
        "System.Xml.XmlSerializer": "4.3.0",
        "System.Data.Common": "4.3.0",
        "System.Diagnostics.StackTrace": "4.3.0",
        "System.Linq": "4.3.0",
        "Microsoft.AspNetCore.Server.Kestrel": "1.1.0",
        "System.Threading": "4.3.0",
        "System.Reflection.TypeExtensions": "4.3.0",
        "System.ComponentModel": "4.3.0",
        "System.Data.SqlClient": "4.3.0",
        "Microsoft.EntityFrameworkCore": "1.1.0"
      },
    
      "tools": {
        "Microsoft.EntityFrameworkCore.Tools": "1.1.0-preview4-final"
      },
    
      "frameworks": {
        "net46": {
          "dependencies": {
            "EntityFramework": "6.1.3",
            "EntityFramework.SqlServerCompact": "6.1.3"
          },
          "buildOptions": {
            "compile": {
              "exclude": [ "Migrations" ]
            }
          }
        },
        "netstandard1.6": {
          "imports": "dnxcore50",
          "dependencies": {
            "Microsoft.AspNetCore.Routing": "1.1.0",
            "Microsoft.Extensions.Configuration.Json": "1.1.0",
            "Microsoft.EntityFrameworkCore.SqlServer": "1.1.0",
            "Microsoft.Extensions.FileSystemGlobbing": "1.1.0",
            "Microsoft.Extensions.Logging": "1.1.0",
            "Microsoft.Extensions.WebEncoders": "1.1.0",
            "Microsoft.Extensions.Logging.Console": "1.1.0",
            "Microsoft.Extensions.Configuration.FileExtensions": "1.1.0",
            "Microsoft.Extensions.Configuration.EnvironmentVariables": "1.1.0",
            "Microsoft.AspNetCore.Server.IISIntegration": "1.1.0",
            "Microsoft.AspNetCore.Mvc.Core": "1.1.0",
            "Microsoft.EntityFrameworkCore.Tools": "1.1.0-preview4-final",
            "NETStandard.Library": "1.6.1",
            "Microsoft.Extensions.Options.ConfigurationExtensions": "1.1.0",
            "Microsoft.EntityFrameworkCore.Design": "1.1.0",
            "Microsoft.EntityFrameworkCore.InMemory": "1.1.0",
            "Microsoft.Extensions.FileProviders.Physical": "1.1.0",
            "Microsoft.Extensions.Configuration": "1.1.0",
            "Microsoft.EntityFrameworkCore.Tools.Core": "1.0.0-rc2-final",
            "Microsoft.AspNetCore.Mvc.ViewFeatures": "1.1.0",
            "Microsoft.EntityFrameworkCore.Relational.Design": "1.1.0",
            "Microsoft.Extensions.Logging.Debug": "1.1.0",
            "Microsoft.AspNetCore.Mvc": "1.1.0",
            "Microsoft.EntityFrameworkCore.Relational": "1.1.0",
            "Microsoft.EntityFrameworkCore.SqlServer.Design": "1.1.0"
          }
        }
      }
    }
