    public async Task<ResponseBaseModel> AddOrderRemark2(AddOrderRemarkRequestModel model)
            {
                try
               {
                    using (ChatEntities context = new ChatEntities(CurrentUsername))
                    {
                        List<string> statusList = await getPendingStatus(context);
                        OrderHeader orderHeader = await getOrderHerderByOrderCode(context, model.OrderCode, model.SalesChannelId);
