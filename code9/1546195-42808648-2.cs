        protected override void OnSubscribeToggle(bool subscribe)
        {
            foreach (var subscribeMethod in GetSubscribeMethods())
            {
                subscribeMethod(subscribe);
            }
        }
