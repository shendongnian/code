    mockOrderManager.Setup(mr => mr.Receive(It.IsAny<List<TransactionVM>>(), It.IsAny<string()))
                    .Returns((List<TransactionVM> target, string status) =>
                             {
                                 // update logic here...
                                 // target.RoleID = transactionList.Count() + 1;
                                 // transactionList.Add(target);
                                 return "OrderReceived";
                             });
