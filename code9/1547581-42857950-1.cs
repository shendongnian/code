    #region IEnumerable
    /// <summary>
    /// Returns an <see cref="IEnumerator{TElement}" /> which when enumerated will execute the query against the database.
    /// </summary>
    /// <returns> The query results. </returns>
    [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
    IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
    {
        ...
    }
    /// <summary>
    /// Returns an <see cref="IEnumerator{TElement}" /> which when enumerated will execute the query against the database.
    /// </summary>
    /// <returns> The query results. </returns>
    [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
    IEnumerator IEnumerable.GetEnumerator()
    {
        ...
    }
    #endregion
