	public class AuthorizationHeaderMessageInspector : IClientMessageInspector, IEndpointBehavior
	{
		object IClientMessageInspector.BeforeSendRequest(ref Message request, IClientChannel channel)
		{
			HttpRequestMessageProperty prop;
			Object obj;
			if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out obj))
			{
				prop = (HttpRequestMessageProperty)obj; // throws a cast exception if invalid type
			}
			else
			{
				prop = new HttpRequestMessageProperty();
				request.Properties.Add(HttpRequestMessageProperty.Name, prop);
			}
			prop.Headers[HttpRequestHeader.Authorization] = "your authorization value here";
			return null;
		}
		void IClientMessageInspector.AfterReceiveReply(ref Message reply, object correlationState)
		{
		}
		void IEndpointBehavior.AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
		{
		}
		void IEndpointBehavior.ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
		{
			clientRuntime.MessageInspectors.Add(this);
		}
		void IEndpointBehavior.ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
		{
		}
		void IEndpointBehavior.Validate(ServiceEndpoint endpoint)
		{
		}
	}
