	namespace Commands
	{
		using System;
		using System.Collections.Generic;
		using System.Linq;
		/// <summary>
		/// Provides an ACK/NACK for an issued <see cref="Command" />.  Can represent one of two states,
		/// being either Acknowledged or Not Acknowledged, along with the ability to track unhandled faults.
		/// </summary>
		/// <remarks>
		/// ACK/NACK implies a synchronous command execution.  Asynchronous commands, while more rarely used,
		/// should represent the concept of command acknowledgement through events.
		/// </remarks>
		public sealed class Acknowledgement
		{
			#region Constructors
			/// <summary>
			/// Initializes a new instance of the <see cref="Acknowledgement"/> class.
			/// </summary>
			/// <remarks>
			/// This is representative of an <see cref="AcknowledgementState.Acknowledged" /> state, with
			/// no command failures nor faults.
			/// </remarks>
			public Acknowledgement()
			{
				this.State = AcknowledgementState.Acknowledged;
				this.CommandFailures = new List<CommandValidationFailure>();    
			}
			/// <summary>
			/// Initializes a new instance of the <see cref="Acknowledgement"/> class.
			/// </summary>
			/// <param name="failures">The command validation failures that led to NACK.</param>
			/// <remarks>
			/// This is representative of a <see cref="AcknowledgementState.NotAcknowledged" /> state, with
			/// at least one command validation failure and no fault.
			/// </remarks>
			public Acknowledgement(IEnumerable<CommandValidationFailure> failures)
			{
				this.State = AcknowledgementState.NotAcknowledged;
				this.CommandFailures = failures;
			}
			/// <summary>
			/// Initializes a new instance of the <see cref="Acknowledgement"/> class.
			/// </summary>
			/// <param name="fault">The fault that led to the NACK.</param>
			/// <remarks>
			/// This is representative of a <see cref="AcknowledgementState.NotAcknowledged" /> state, with
			/// a fault and no command validation failures.
			/// </remarks>
			public Acknowledgement(Exception fault)
			{
				this.State = AcknowledgementState.NotAcknowledged;
				this.Fault = fault;
			}
			#endregion
			#region Public Properties
			/// <summary>
			/// Gets the command failures that led to a NACK, if any.
			/// </summary>
			/// <value>
			/// The command failures, if present.
			/// </value>
			public IEnumerable<CommandValidationFailure> CommandFailures { get; }
			/// <summary>
			/// Gets the fault that led to a NACK, if present.
			/// </summary>
			/// <value>
			/// The fault.
			/// </value>
			public Exception Fault { get; }
			/// <summary>
			/// Gets a value indicating whether this <see cref="Acknowledgement" /> is backed by a fault.
			/// </summary>
			/// <value>
			/// <c>true</c> if this instance is reflective of a fault; otherwise, <c>false</c>.
			/// </value>
			public bool IsFaulted => this.Fault != null;
			/// <summary>
			/// Gets a value indicating whether this <see cref="Acknowledgement" /> is backed by command validation failures.
			/// </summary>
			/// <value>
			/// <c>true</c> if this instance is reflective of command failures; otherwise, <c>false</c>.
			/// </value>
			public bool IsInvalid => this.CommandFailures != null && this.CommandFailures.Any();
			/// <summary>
			/// Gets the state of this instance, in terms of an ACK or NACK.
			/// </summary>
			/// <value>
			/// The state representation.
			/// </value>
			public AcknowledgementState State { get; }
			#endregion
		}
	}
