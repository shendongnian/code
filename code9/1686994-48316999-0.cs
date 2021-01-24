    /// <summary>
	/// Creates an <see cref="IMqttServer"/> over the TCP protocol, using the 
	/// specified MQTT configuration to customize the protocol parameters.
	/// </summary>
	/// <param name="configuration">
	/// The configuration used for creating the Server.
	/// See <see cref="MqttConfiguration" /> for more details about the supported values.
	/// </param>
	/// <param name="authenticationProvider">
	/// Optional authentication provider to use, 
	/// to enable authentication as part of the connection mechanism.
	/// See <see cref="IMqttAuthenticationProvider" /> for more details about how to implement
	/// an authentication provider.
	/// </param>
	/// <returns>A new MQTT Server</returns>
