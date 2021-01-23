	namespace Commands
	{
		using System;
		using System.Collections.Generic;
		using System.Runtime.Serialization;
		/// <summary>
		/// Thrown when on or more violations are found during the attempted execution of a command.
		/// </summary>
		/// <remarks>
		/// In general, this exception is thrown as a guard against non-validation of a command ahead
		/// of application.  The most feasible scenario is a command handler which attempts to skip
		/// validation, prior to execution.
		/// </remarks>
		[Serializable]
		public class CommandValidationException : Exception
		{
			#region Constructors
			/// <summary>
			/// Initializes a new instance of the <see cref="CommandValidationException"/> class.
			/// </summary>
			/// <param name="violations">The violations leading to this exception being thrown.</param>
			public CommandValidationException(List<DomainValidationFailure> violations)
			{
				this.Violations = violations;
			}
			/// <summary>
			/// Initializes a new instance of the <see cref="CommandValidationException"/> class.
			/// </summary>
			/// <param name="violations">The violations leading to this exception being thrown.</param>
			/// <param name="message">The message to associate with the exception.</param>
			public CommandValidationException(List<DomainValidationFailure> violations, string message) : base(message)
			{
				this.Violations = violations;
			}
			/// <summary>
			/// Initializes a new instance of the <see cref="CommandValidationException"/> class.
			/// </summary>
			/// <param name="violations">The violations leading to this exception being thrown.</param>
			/// <param name="message">The message to associate with the exception.</param>
			/// <param name="innerException">The inner exception to associate with this exception.</param>
			public CommandValidationException(List<DomainValidationFailure> violations, string message, Exception innerException) : base(message, innerException)
			{
				this.Violations = violations;
			}
			/// <summary>
			/// Initializes a new instance of the <see cref="CommandValidationException"/> class.
			/// </summary>
			/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
			/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
			public CommandValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
			#endregion
			#region Public Properties
			/// <summary>
			/// Gets the violations associated to this exception.
			/// </summary>
			/// <value>
			/// The violations associated with this exception.
			/// </value>
			public List<DomainValidationFailure> Violations { get; }
			#endregion
		}
	}
