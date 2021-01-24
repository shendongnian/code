     var serviceFactory = new ServiceFactory();
            serviceFactory.Register("Enrol", typeof(EnrolmentRequest));
            serviceFactory.Register("ReEnrol", typeof(REnrolmentRequest));
            serviceFactory.Register("DeleteEnrolment", typeof(UpdateEnrolmentRequest));
            serviceFactory.Register("UpdateEnrolment", typeof(UpdateEnrolmentRequest));
