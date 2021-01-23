    public Transaction[] GetAllBookingInfo(string memberId, string partnerId)
    {
        AllBookingsByMemberIdRS response;
        using (var client = new MembershipClient())
        using (new OperationContextScope(client.InnerChannel))
        {
            // add the basic auth header
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name]
                = GetBasicAuthHeader("user", "pass");
            var request = new AllBookingsByMemberIdRQ
            {
                MemberId = memberId,
                PartnerId = partnerId
            };
            response = client.GetAllBookingsByMemberId(request);
        }
        return response.Transactions;
    }
