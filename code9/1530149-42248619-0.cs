    public enum OperationType
    {
        Enrol,
        ReEnrol,
        DeleteEnrolment,
        UpdateEnrolment
    }
            //register types
            builder.RegisterType<EnrolmentRequest>().Keyed<IRequest>(OperationType.Enrol);
            builder.RegisterType<ReEnrolmentRequest>().Keyed<IRequest>(OperationType.ReEnrol);
            builder.RegisterType<UpdateEnrolmentRequest>().Keyed<IRequest>(OperationType.DeleteEnrolment | OperationType.UpdateEnrolment);
            // resolve by operationType enum
            var request = container.ResolveKeyed<IRequest>(OperationType.Enrol);
