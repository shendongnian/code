    // Decompiled with JetBrains decompiler
    // Type: Owin.IAppBuilder
    // Assembly: Owin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f0ebd12fd5e55cc5
    // MVID: C152461C-65C1-4F51-912C-2454A21D9BAD
    // Assembly location: E:\Felinesoft\BACP\DEV\WEB\BACP.Web-AzureSearch\BACP.Web.Presentation\Bin\Owin.dll
    
    using System;
    using System.Collections.Generic;
    
    namespace Owin
    {
      public interface IAppBuilder
      {
        IDictionary<string, object> Properties { get; }
    
        IAppBuilder Use(object middleware, params object[] args);
    
        object Build(Type returnType);
    
        IAppBuilder New();
      }
    }
