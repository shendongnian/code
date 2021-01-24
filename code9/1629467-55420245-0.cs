    bool CheckError(AggregateException exception, int firebaseExceptionCode)
        {
            Firebase.FirebaseException fbEx = null;
            foreach (Exception e in exception.Flatten().InnerExceptions)
            {
            fbEx = e as Firebase.FirebaseException;
            if (fbEx != null)
                break;
        }
    
        if (fbEx != null)
        {
            if (fbEx.ErrorCode == firebaseExceptionCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
