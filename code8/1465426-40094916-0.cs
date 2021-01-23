    System.TypeInitializationException was unhandled by user code
      HResult=-2146233036
      Message=The type initializer for 'ExtentPlaceholderCreator' threw an exception.
      Source=System.Data.Entity
      TypeName=ExtentPlaceholderCreator
      StackTrace:
           at System.Data.Mapping.Update.Internal.Propagator.ExtentPlaceholderCreator.GetPropagatorResultForPrimitiveType(PrimitiveType primitiveType, PropagatorResult& result)
           at System.Data.Mapping.Update.Internal.Propagator.ExtentPlaceholderCreator.Visit(EdmMember node)
           at System.Data.Mapping.Update.Internal.Propagator.ExtentPlaceholderCreator.CreateEntitySetPlaceholder(EntitySet entitySet)
           at System.Data.Mapping.Update.Internal.Propagator.ExtentPlaceholderCreator.CreatePlaceholder(EntitySetBase extent, UpdateTranslator parent)
           at System.Data.Mapping.Update.Internal.Propagator.Visit(DbScanExpression node)
           at System.Data.Common.CommandTrees.DbScanExpression.Accept[TResultType](DbExpressionVisitor`1 visitor)
           at System.Data.Mapping.Update.Internal.UpdateExpressionVisitor`1.Visit(DbExpression expression)
           at System.Data.Mapping.Update.Internal.Propagator.Visit(DbProjectExpression node)
           at System.Data.Common.CommandTrees.DbProjectExpression.Accept[TResultType](DbExpressionVisitor`1 visitor)
           at System.Data.Mapping.Update.Internal.Propagator.Propagate(UpdateTranslator parent, EntitySet table, DbQueryCommandTree umView)
           at System.Data.Mapping.Update.Internal.UpdateTranslator.<ProduceDynamicCommands>d__44.MoveNext()
           at System.Linq.Enumerable.<ConcatIterator>d__58`1.MoveNext()
           at System.Data.Mapping.Update.Internal.UpdateCommandOrderer..ctor(IEnumerable`1 commands, UpdateTranslator translator)
           at System.Data.Mapping.Update.Internal.UpdateTranslator.ProduceCommands()
           at System.Data.Mapping.Update.Internal.UpdateTranslator.Update(IEntityStateManager stateManager, IEntityAdapter adapter)
           at System.Data.EntityClient.EntityAdapter.Update(IEntityStateManager entityCache)
           at System.Data.Objects.ObjectContext.SaveChanges(SaveOptions options)
           at System.Data.Entity.Internal.InternalContext.SaveChanges()
           at System.Data.Entity.Internal.LazyInternalContext.SaveChanges()
           at System.Data.Entity.DbContext.SaveChanges()
           at MvcAuction.Controllers.AuctionsController.Create(Auction auction) in c:\Users\ZOHNPJ\Documents\Ex_Files_ASP.NET_MVC4_EssT\Ex_Files_ASP.NET_MVC4_EssT\Exercise Files\06_04\MvcAuction\MvcAuction\Controllers\AuctionsController.cs:line 80
           at lambda_method(Closure , ControllerBase , Object[] )
           at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
           at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
           at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
           at System.Web.Mvc.Async.AsyncControllerActionInvoker.InvokeSynchronousActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
           at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass42.<BeginInvokeSynchronousActionMethod>b__41()
           at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass8`1.<BeginSynchronous>b__7(IAsyncResult _)
           at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
           at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)
           at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
           at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<>c__DisplayClass39.<BeginInvokeActionMethodWithFilters>b__33()
           at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass4f.<InvokeActionMethodFilterAsynchronously>b__49()
      InnerException: System.Reflection.TargetInvocationException
           HResult=-2146232828
           Message=Exception has been thrown by the target of an invocation.
           Source=mscorlib
           StackTrace:
                at System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments, Signature sig, Boolean constructor)
                at System.Reflection.RuntimeMethodInfo.UnsafeInvokeInternal(Object obj, Object[] parameters, Object[] arguments)
                at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
                at System.Data.SqlClient.SqlSpatialServices.GeometryFromText(String geometryText)
                at System.Data.Spatial.DbGeometry.FromText(String wellKnownText)
                at System.Data.Mapping.Update.Internal.Propagator.ExtentPlaceholderCreator.InitializeTypeDefaultMap()
                at System.Data.Mapping.Update.Internal.Propagator.ExtentPlaceholderCreator..cctor()
           InnerException: System.EntryPointNotFoundException
                HResult=-2146233053
                Message=Unable to find an entry point named 'SetClrFeatureSwitchMap' in DLL 'SqlServerSpatial110.dll'.
                Source=Microsoft.SqlServer.Types
                TypeName=""
                StackTrace:
                     at Microsoft.SqlServer.Types.GLNativeMethods.SetClrFeatureSwitchMap(Int32 clrFeatureSwitchMap)
                     at Microsoft.SqlServer.Types.SqlGeometry.IsValidExpensive()
                     at Microsoft.SqlServer.Types.SqlGeometry..ctor(GeoData g, Int32 srid)
                     at Microsoft.SqlServer.Types.SqlGeometry.Construct(GeoData g, Int32 srid)
                     at Microsoft.SqlServer.Types.SqlGeometry.GeometryFromText(OpenGisType type, SqlChars text, Int32 srid)
                     at Microsoft.SqlServer.Types.SqlGeometry.STGeomFromText(SqlChars geometryTaggedText, Int32 srid)
                     at Microsoft.SqlServer.Types.SqlGeometry.Parse(SqlString s)
                InnerException: 
