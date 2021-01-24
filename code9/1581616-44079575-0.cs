    var paymentReceivedAmt = (from registerEntry in RegisterEntries
        where registerEntry.TransactionType != null
        && registerEntry.TransactionType.Id.SubsystemCode == "A"
        && registerEntry.Receipt != null
        && registerEntry.PostDate != null
        && (registerEntry.AddedDate == registerEntry.PostDate
                ? registerEntry.AddedDate
                : registerEntry.PostDate) >= lastInvoicedDate
        select registerEntry.TransactionAmount.GetValueOrDefault(0)).Sum();
