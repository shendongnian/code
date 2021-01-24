    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace CompanyNamespace.Server.DataAdaptersCommon
    {
        /// <summary>
        /// A wrapper around sp_GetAppLock (SQL Server), useful for global locking (by arbitrary name) across multiple machines.
        /// For instance:  Include the compatibility version number within the lock resource to create a version specific lock.
        /// </summary>
        public class GlobalApplicationSqlServerLock : SimplifiedDisposableBase
        {
            /// <summary>
            /// Last returned value from sp_GetAppLock() or sp_ReleaseAppLock()
            /// </summary>
            public Int32 LastReturnCode { get; private set; }
    
             /// <summary>
            /// The SQL Connection to use.
            /// </summary>
            readonly SqlConnection _connection;
    
            /// <summary>
            /// The name of the lock chosen by the callse
            /// </summary>
            readonly string _lockName;
            
            /// <summary>
            /// The cumulative times that Lock() has been called.
            /// </summary>
            int _lockCount;
    
            // Refer to sp_GetAppLock()
            //
            const string _lockOwner = "session";
            const string _lockMode = "Exclusive";
            const string _dbPrincipal = "public";
    
            /// <summary>
            /// Wait a maximum of this many seconds.
            /// </summary>
            Int32 _waitForLockMaxSeconds;
    
            /// <summary>
            /// Constructor accepting a Connection String
            /// </summary>
            /// <param name="connectionString">Connection string should include "...;AppName=AppType,WebPid" to improve DB side logging.</param>
            /// <param name="lockName"></param>
            /// <param name="waitForLockMaxSeconds">Throw an exception if the lock cannot be acquired within this time period.</param>
            /// <param name="lockNow">True to obtain the lock via the contructor call.  Lock is always released in Dipose()</param>
            /// <param name="excludeFromOpenTransactionScope">True to exclude from any open TransactionScope</param>
            public GlobalApplicationSqlServerLock(
                string connectionString, 
                string lockName,
                Int32 waitForLockMaxSeconds = 30, 
                bool lockNow = true,
                bool excludeFromOpenTransactionScope = true)
            {
                SqlConnectionStringBuilder conStrBuilder = new SqlConnectionStringBuilder(connectionString);
    
                if (excludeFromOpenTransactionScope)
                    conStrBuilder.Enlist = false;
    
                _waitForLockMaxSeconds = waitForLockMaxSeconds;
    
                // The lock must use a dedicated connection that stays open for the duration of the lock.
                // Otherwise, since the lock owner is "session", when the connection is closed the lock "may" be 
                // released since connection pooling could have inconsistent side effects.  So caller must ensure
                // lock is released (using IDisposable, etc).
                //
                _connection = new SqlConnection(conStrBuilder.ConnectionString);           
                _connection.Open();
                _lockName = lockName;
    
                if (lockNow)
                    Lock();
            }
    
            /// <summary>
            /// Lock
            /// </summary>
            public void Lock()
            {
                string errMsg;
                if (!TryLock(out errMsg))
                    throw new Exception(errMsg);
            }
    
            /// <summary>
            /// Try lock
            /// </summary>
            /// <param name="errMsg"></param>
            /// <returns>True if lock obtained, false if not with error message.</returns>
            public bool TryLock(out string errMsg)
            {                    
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = _connection;
                    command.CommandType = CommandType.StoredProcedure;
    
                    command.CommandText = "sp_GetAppLock"; 
                    command.Parameters.Add(new SqlParameter("@Resource", SqlDbType.NVarChar, 255) { Value = _lockName });
                    command.Parameters.Add(new SqlParameter("@LockMode", SqlDbType.NVarChar, 32) { Value = _lockMode });
                    command.Parameters.Add(new SqlParameter("@LockOwner", SqlDbType.NVarChar, 32) { Value = _lockOwner });
                    command.Parameters.Add(new SqlParameter("@LockTimeout", SqlDbType.Int) { Value = _waitForLockMaxSeconds });
                    command.Parameters.Add(new SqlParameter("@DBPrincipal", SqlDbType.NVarChar, 128) { Value = _dbPrincipal }); 
                    command.Parameters.Add(new SqlParameter("@Result", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue });
     
                    command.ExecuteNonQuery();
     
                    LastReturnCode =  (int)command.Parameters["@Result"].Value;
                }
     
                switch (LastReturnCode)
                {
                    case 0:
                    case 1:
                        _lockCount++;
                        errMsg = null;
                        return true;
                    case -1:
                        errMsg = "The lock request timed out.";
                        break;
                    case -2:
                        errMsg = "The lock request was canceled.";
                        break;
                    case -3:
                        errMsg = "The lock request was chosen as a deadlock victim.";
                        break;
                    case -999:
                        errMsg = "Indicates a parameter validation or other call error.";
                        break;
                    default:
                        errMsg = "Unexpected return value";
                        break;
                }
    
                return false;            
            }
     
            /// <summary>
            /// Release the lock
            /// </summary>
            public void Release()
            {
                string errMsg;
     
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = _connection;
                    command.CommandType = CommandType.StoredProcedure;
    
                    command.CommandText = "sp_ReleaseAppLock";
                    command.Parameters.Add(new SqlParameter("@Resource", SqlDbType.NVarChar, 255) { Value = _lockName }); 
                    command.Parameters.Add(new SqlParameter("@LockOwner", SqlDbType.NVarChar, 32) { Value = _lockOwner });
                    command.Parameters.Add(new SqlParameter("@DBPrincipal", SqlDbType.NVarChar, 128) { Value = _dbPrincipal }); 
                    command.Parameters.Add(new SqlParameter("@Result", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue });
     
                    command.ExecuteNonQuery();
                    LastReturnCode = (int)command.Parameters["@Result"].Value;
                }
     
                switch (LastReturnCode)
                {
                    case 0:
                        _lockCount--;
                        return;
                    case -999:
                        errMsg = "Indicates a parameter validation or other call error.";
                        break;
                    default:
                        errMsg = "Unexpected return value";
                        break;
                }
     
                throw new Exception(errMsg); 
            }
     
            /// <summary>
            /// Disposable implmentation
            /// </summary>
            protected override void FreeManagedResources()
            {            
                try
                {
                    while (_lockCount > 0)
                        Release();
                }
                finally
                {
                    try
                    {
                        if (_connection != null && _connection.State != ConnectionState.Closed)
                            _connection.Close();
                    }
                    finally
                    {
                        base.FreeManagedResources();
                    }
                }             
            }
        }
    }
    
    
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace CompanyNamespace.Common
    {
        /// <summary>
        /// To support IDisposable, pass true to constructor and call:
        /// 
        ///         AutoDispose(IDisposable) for each disposable at time of creation,
        ///         
        /// Or override these as needed:
        /// 
        ///         FreeManagedResources() and 
        ///         FreeUnmanagedResources()
        ///         
        /// Multi-thread safe.
        /// </summary>
        public abstract class SimplifiedDisposableBase : IDisposable
        {
            /// <summary>
            /// Flag for IDisposable
            /// </summary>
            protected bool _isDisposed = false;
    
            /// <summary>
            /// List of items that should be Dispose() when the instance is Disposed()
            /// </summary>
            private List<IDisposable> _autoDisposables = new List<IDisposable>();
    
            /// <summary>
            /// Constructor
            /// </summary>
            public SimplifiedDisposableBase()
            {
            }
    
            /// <summary>
            /// Finalizer (needed for freeing unmanaged resources and adds a check a Dispose() check for managed resources).
            /// </summary>
            ~SimplifiedDisposableBase()
            {
                // Warning:  An exception here will end the application.
                // Do not attempt to lock to a possibly finalized object within finalizer
                // http://stackoverflow.com/questions/4163603/why-garbage-collector-takes-objects-in-the-wrong-order            
    
                string errMessages = string.Empty;
                try
                {
                    errMessages = String.Format("Warning:  Finalizer was called on class '{0}' (base class '{1}').  " +
                        "IDisposable's should usually call Dispose() to avoid this.  (IsDisposed = {2})",
                        GetType().FullName,
                        typeof(SimplifiedDisposableBase).FullName,
                        _isDisposed);
    
                    Debug.WriteLine(errMessages);
    
                    Dispose(false);     // free any unmanaged resources                
                }
    #if DEBUG
                catch (Exception ex)
                {
                    errMessages = "Fatal:  Exception occurred within Finalizer ~" + GetType().FullName + "()." + errMessages;
                    Debug.WriteLine(errMessages + "  " + ex.Message);
    
                    // Verified that this exception appears in Windows Event Log and includes the originating class message and StackTrace[0]
                    throw new Exception(errMessages, ex);
                }
    #else
                catch (Exception) 
                {
                    /* Don't exit the application */ 
                }
    #endif
            }
    
            /// <summary>
            /// Add an managed item to be automatically disposed when the class is disposed.
            /// </summary>
            /// <param name="disposable"></param>
            /// <returns>The argument</returns>
            public T AutoDispose<T>(T disposable) where T : IDisposable
            {
                lock (_autoDisposables)
                    _autoDisposables.Add(disposable);
    
                return disposable;
            }        
    
            /// <summary>
            /// Derived class can override and chain for support of IDisposable managed resources.
            /// </summary>
            protected virtual void FreeManagedResources() 
            {
                lock (_autoDisposables)
                {
                    _autoDisposables
                        .ForEach(d => d.Dispose());
    
                    _autoDisposables.Clear();
                }
            }
            
            /// <summary>
            /// Derived class can optionally override for support of IDisposable unmanaged resources.
            /// </summary>
            protected virtual void FreeUnmanagedResources() { }
    
            /// <summary>
            /// Standard IDisposable Implmentation
            /// </summary>
            public void Dispose()
            {
                Dispose(true);  // calling multiple times is okay
                GC.SuppressFinalize(this);  // http://stackoverflow.com/questions/12436555/calling-suppressfinalize-multiple-times is okay
            }
            
            /// <summary>
            /// Dispose
            /// </summary>
            protected virtual void Dispose(bool isDisposing)        
            {            
                if (!isDisposing) // if called from finalizer, do not use lock (causes exception)
                {
                    if (!_isDisposed)
                    {
                        FreeUnmanagedResources();   // always free these                
                        _isDisposed = true;
                    }
                    return;
                }
    
                // Remainder is called from IDisposable (not finalizer)
    
                // Based on "Implemenent IDisposable Correctly" 
                // http://msdn.microsoft.com/en-us/library/ms244737.aspx
           
                lock (_autoDisposables)
                {
                    if (_isDisposed)
                        return; // the docs specifically state that Dispose() must be callable multiple times without raising an exception
    
                    try
                    {
                        try
                        {
                            FreeManagedResources();
                        }
                        finally
                        {
                            FreeUnmanagedResources();   // always free these
                        }
                    }
                    finally
                    {
                        _isDisposed = true;
                    }
                }
            }       
        }     
    }
