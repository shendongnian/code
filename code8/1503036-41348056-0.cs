        protected override IDispatchMessageFormatter GetRequestDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
        {
            if (operationDescription.IsGetOrDeleteOperation())
            {
                // no change for GET operations
                return base.GetRequestDispatchFormatter(operationDescription, endpoint);
            }
            if (operationDescription.Messages[0].Body.Parts.Count == 0)
            {
                // nothing in the body, still use the default
                return base.GetRequestDispatchFormatter(operationDescription, endpoint);
            }
            return new NewtonsoftJsonDispatchFormatter(operationDescription, true);
        }
