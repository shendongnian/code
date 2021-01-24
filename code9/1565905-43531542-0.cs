        Recipients.Add(new Recipient
        {
            UserName = row["FirstSigner"].ToString(),
            Email = row["SignerEmail"].ToString(),
            ID = "1",
            Type = RecipientTypeCode.Signer,
            CaptiveInfo = new RecipientCaptiveInfo
            { 
                ClientUserId = "1",
                EmbeddedRecipientStartURL = "<Url to your App>"
            },
            RoleName = "Signer1",
            RoutingOrder = 1
        });
