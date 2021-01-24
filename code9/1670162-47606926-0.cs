    private void ProcessVerificationResponse(string verificationResponse)
    {
        if (verificationResponse.Equals("VERIFIED"))
        {
            // check that Payment_status=Completed
            // check that Txn_id has not been previously processed
            // check that Receiver_email is your Primary PayPal email
            // check that Payment_amount/Payment_currency are correct
            // process payment
        }
        else if (verificationResponse.Equals("INVALID"))
        {
            //Log for manual investigation
        }
        else
        {
            //Log error
        }
    }
