    using System;
    using System.Collections.ObjectModel;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    namespace Utils
    {
        public class HttpErrorHandler : IErrorHandler
        {
            public bool HandleError(Exception error)
            {
                return false;
            }
            public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
            {
                if (error != null) // Notify ELMAH of the exception.
                {
                    Elmah.ErrorSignal.FromCurrentContext().Raise(error);
                }
            }
        }
        /// <summary>
        /// So we can decorate Services with the [ServiceErrorBehaviour(typeof(HttpErrorHandler))]
        /// ...and errors reported to ELMAH
        /// </summary>
        public class ServiceErrorBehaviourAttribute : Attribute, IServiceBehavior
        {
            Type errorHandlerType;
            public ServiceErrorBehaviourAttribute(Type errorHandlerType)
            {
                this.errorHandlerType = errorHandlerType;
            }
            public void Validate(ServiceDescription description, ServiceHostBase serviceHostBase)
            {
            }
            public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
                BindingParameterCollection bindingParameters)
            {
            }
            public void ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase serviceHostBase)
            {
                IErrorHandler errorHandler;
                errorHandler = (IErrorHandler)Activator.CreateInstance(errorHandlerType);
                foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
                {
                    ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                    channelDispatcher.ErrorHandlers.Add(errorHandler);
                }
            }
        }
    }
