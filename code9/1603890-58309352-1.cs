    public class AopAction<T>:DispatchProxy
    {
      #region Private Fields
      private Action<MethodInfo,object[],object> ActAfter;
      private Action<MethodInfo,object[]> ActBefore;
      private Action<MethodInfo,object[],Exception> ActException;
      private T Decorated;
      #endregion Private Fields
    
      #region Public Methods
      public static T Create(T decorated,Action<MethodInfo,object[]> actBefore = null,Action<MethodInfo,object[],object> actAfter = null,Action<MethodInfo,object[],Exception> actException = null)
      {
        object proxy = Create<T,AopAction<T>>();
        SetParameters();
        return (T)proxy;
        void SetParameters()
        {
          var me = ((AopAction<T>)proxy);
          me.Decorated = decorated == default ? throw new ArgumentNullException(nameof(decorated)) : decorated;
          me.ActBefore = actBefore;
          me.ActAfter = actAfter;
          me.ActException = actException;
        }
      }
      #endregion Public Methods
    
      #region Protected Methods
      protected override object Invoke(MethodInfo targetMethod,object[] args)
      {
        _ = targetMethod ?? throw new ArgumentException(nameof(targetMethod));
    
        try
        {
          ActBefore?.Invoke(targetMethod,args);
          var result = targetMethod.Invoke(Decorated,args);
          ActAfter?.Invoke(targetMethod,args,result);
          return result;
        }
        catch(Exception ex)
        {
          ActException?.Invoke(targetMethod,args,ex);
          throw ex.InnerException;
        }
      }
      #endregion Protected Methods
    }
