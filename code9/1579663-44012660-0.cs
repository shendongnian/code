    bool subscriptionSucceeded = APIHelper.CreateSubscription( Order );
    bool paymentSucceeded = APIHelper.MakePayment( Order );
    if( !subscriptionSucceeded && paymentSucceeded )
    {
        // Error logic 1
    }
    else if( !paymentSucceeded )
    {
        // Error logic 2
    }
