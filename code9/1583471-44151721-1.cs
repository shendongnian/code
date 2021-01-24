    [global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.MultiResultsTest")]
	[global::System.Data.Linq.Mapping.ResultTypeAttribute(typeof(CustomerResult))]
	[global::System.Data.Linq.Mapping.ResultTypeAttribute(typeof(ProductResult))]
	public IMultipleResults MultiResultsTest([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> iCustomerID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> iProductID)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iCustomerID, iProductID);
		return ((IMultipleResults)(result.ReturnValue));
	}
