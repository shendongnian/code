    class ManualRequestDispatcher : IRequestDispatcher {
        public void Dispatch<TRequest>(TRequest request) {
            var handler = (IRequestHandler<TRequest>)CreateHandler(typeof(TRequest));
            handler.Handle(request);
        }
        object CreateHandler(Type type) =>
            type == typeof(DoEnrolment)? new DoEnrolmentHandler() :
            type == typeof(DoReenrolment) ? new DoReenrolment() :
            type == typeof(DeleteEnrolment) ? new DeleteEnrolment() :
            type == typeof(UpdateEnrolment) ? new UpdateEnrolment() :
            ThrowRequestUnknown(type);
        object ThrowRequestUnknown(Type type) {
            throw new InvalidOperationException("Unknown request " + type.Name);
        }
    }
