    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Filters;
    using Demo.Models;
    
    namespace Demo.Controllers
    {
        public class ValuesController : ApiController
        {
            
            // DELETE api/values/5
    
            [OperationError("The operation failed to delete the entity")]
            public OperationResult Delete(int id)
            {
                throw new ArgumentException("ID is bad", nameof(id));
            }
    
            // DELETE api/values/5?specific=[true|false]
    
            [OperationError("The operation tried to divide by zero", typeof(DivideByZeroException))]
            [OperationError("The operation failed for no specific reason")]
            public OperationResult DeleteSpecific(int id, bool specific)
            {
                if (specific)
                {
                    throw new DivideByZeroException("DBZ");
                }
                else
                {
                    throw new ArgumentException("ID is bad", nameof(id));
                }
            }
        }
    
        public class OperationErrorAttribute : ExceptionFilterAttribute
        {
            public Type ExceptionType { get; }
            public string ErrorMessage { get; }
    
            public OperationErrorAttribute(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
    
            public OperationErrorAttribute(string errorMessage, Type exceptionType)
            {
                ErrorMessage = errorMessage;
                ExceptionType = exceptionType;
            }
    
            public override void OnException(HttpActionExecutedContext actionExecutedContext)
            {
                // Exit early for non OperationResult action results
                if (actionExecutedContext.ActionContext.ActionDescriptor.ReturnType != typeof(OperationResult))
                {
                    base.OnException(actionExecutedContext);
                    return;
                }
                    
                OperationResult result = new OperationResult() {Success = false};
    
                // Add error for specific exception types
                Type exceptionType = actionExecutedContext.Exception.GetType();
    
                if (ExceptionType != null)
                {
                    if (exceptionType == ExceptionType)
                    {
                        result.AddError(ErrorMessage);
                    }
                    else
                    {
                        // Fall through
                        base.OnException(actionExecutedContext);
                        return;
                    }
                }
                else if (ErrorMessage != null)
                {
                    result.AddError(ErrorMessage);
                }
    
                // TODO: Log exception, generate correlation ID, etc.
                
                // Set new result
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, result);
    
                base.OnException(actionExecutedContext);
            }
        }
    }
