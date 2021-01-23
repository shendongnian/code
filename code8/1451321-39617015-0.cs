    Property(p => p.CountryCode, m =>
            {
                m.Length(10);
                m.NotNullable(true);
                m.Index("PanelShopCountryCodeIdx");
                //m.UniqueKey("UK_psPanelShopnrIdx");
            });
            Property(p => p.ShopNr, m =>
            {
                m.Length(25);
                m.NotNullable(true);
                //m.UniqueKey("UK_psPanelShopnrIdx");
            });
            Property(p => p.PanelCode, m =>
            {
                m.Length(25);
                m.NotNullable(true);
               // m.UniqueKey("UK_psPanelShopnrIdx");
            });
