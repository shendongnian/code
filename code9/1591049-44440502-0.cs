            if (!IsPostBack)
            {  
                BillingInformation.HeaderContainer.Style.Add("pointer-events", "auto");
                ShippingInformation.HeaderContainer.Style.Add("pointer-events", "none");
                DelieveryMethodsPanel.HeaderContainer.Style.Add("pointer-events", "none");
                PromoCode.HeaderContainer.Style.Add("pointer-events", "none");
                PaymentInformation.HeaderContainer.Style.Add("pointer-events", "none");
            }
