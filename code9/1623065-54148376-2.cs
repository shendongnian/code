System.InvalidOperationException: StatusCode cannot be set because the response has already started.
   at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol.ThrowResponseAlreadyStartedException(String value)
   at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol.set_StatusCode(Int32 value)
   at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol.Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.set_StatusCode(Int32 value)
   at Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse.set_StatusCode(Int32 value)
   at Microsoft.AspNetCore.Mvc.StatusCodeResult.ExecuteResult(ActionContext context)
   at Microsoft.AspNetCore.Mvc.ActionResult.ExecuteResultAsync(ActionContext context)
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeResultAsync(IActionResult result)
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeNextResultFilterAsync[TFilter,TFilterAsync]()
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResultExecutedContext context)
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.ResultNext[TFilter,TFilterAsync](State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeResultFilters()
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeNextResourceFilter()
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResourceExecutedContext context)
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeFilterPipelineAsync()
   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeAsync()
   at Microsoft.AspNetCore.Builder.RouterMiddleware.Invoke(HttpContext httpContext)
   at Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Cors.Infrastructure.CorsMiddleware.Invoke(HttpContext context)
   at MyApp.Middleware.MyAppNotFoundHandlerMiddleware.Invoke(HttpContext context) in C:\Proj\MyApp\Middleware\MyAppNotFoundHandlerMiddleware.cs:line 24
   at MyApp.Middleware.MyAppExceptionHandlerMiddleware.Invoke(HttpContext context) in C:\Proj\MyApp\Middleware\MyAppExceptionHandlerMiddleware.cs:line 26
   at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol.ProcessRequests[TContext](IHttpApplication`1 application)
Here's the controller action where it went wrong:
[HttpGet]
[AllowAnonymous]
public async Task<IActionResult> Get()
{
	if (HttpContext.WebSockets.IsWebSocketRequest)
	{
		var socket = await HttpContext.WebSockets.AcceptWebSocketAsync();
		Clients.Add(socket);
		await WaitForClose(HttpContext, socket);
	}
	return Ok();
}
And as mentioned by the other answers, the culprit is the `return Ok()`. This statement is executed when the socket closes, but by then, the HTTP connection has long been closed.
I was using the NuGet package `Microsoft.AspNetCore.WebSockets` version 2.1.0.
