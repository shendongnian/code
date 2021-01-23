    public void m_ts_OrderAdded(object sender, OrderAddedEventArgs e)
        {
            string key = e.Order.SiteOrderKey;
            if (key == m_oKeys[0])
            {
                // Do something
            }
            else
            {
                // Do something else
            }
        }
