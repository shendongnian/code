	public static class OperatorDiagnosticsConstant
	{
		public readonly string Value;
		public readonly MaintenanceCounterType CounterType;
		private OperatorDiagnosticsConstant(string value, MaintenanceCounterType counterType)
		{
			Value = value;
			CounterType = counterType;
		}
		public static OperatorDiagnosticsConstant R1_PROBE_CODE = new OperatorDiagnosticsConstant("SACT-158", MaintenanceCounterType.ReagentProbe1);
	}
