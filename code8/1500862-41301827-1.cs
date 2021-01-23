	namespace Commands
	{
		/// <summary>
		/// Provides a simple expression of acknowledgement state (ACK/NACK).
		/// </summary>
		public enum AcknowledgementState
		{
			/// <summary>
			/// Indicates an ACK that contains no command failures nor a fault.
			/// </summary>
			Acknowledged,
			/// <summary>
			/// Indicates a NACK that contains either command failures or a fault.
			/// </summary>
			NotAcknowledged
		}
	}
