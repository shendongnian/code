    Startup.cs
    using Microsoft.AspNetCore.Http.Internal;
    
    Startup.Configure(...){
    ...
    //Its important the rewind us added before UseMvc
    app.Use(next => context => { context.Request.EnableRewind(); return next(context); });
    app.UseMvc()
    ...
    }
