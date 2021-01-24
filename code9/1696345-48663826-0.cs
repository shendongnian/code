        private TelemetryClient telemetry = new TelemetryClient();
        public override void HandleUncaughtException(IRequest httpReq, IResponse httpRes, string operationName, Exception ex)
        {
            telemetry.TrackException(ex);
            if (!(ex is SerializationException))
            { // don't handle like BadRequest if not serialization exception
                base.HandleUncaughtException(httpReq, httpRes, operationName, ex);
                return;
            }
            httpRes.WriteError(new HttpError(HttpStatusCode.BadRequest, ex.InnerException?.Message), (int)HttpStatusCode.BadRequest);
            httpRes.EndRequest(skipHeaders: true);
        }
        public override Exception ResolveResponseException(Exception ex)
        {
            telemetry.TrackException(ex);
            if (ex.GetType() == typeof(HttpError))
            { // Exception thrown using HttpError, do not sanitize
                
                return ex;
            }
            return new HttpError(HttpStatusCode.InternalServerError, "The service has encountered an error, please contact your account manager if this persists.");
        }
