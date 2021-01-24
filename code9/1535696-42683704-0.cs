        if (transactionDetails.Ack == AckCodeType.FAILURE)
        {
            foreach (var e in transactionDetails.Errors)
            {
                Console.WriteLine(e.LongMessage); // 
            }
        }
