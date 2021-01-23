        public override void OnUserInteraction()
        {
            base.OnUserInteraction();
            SessionManager.Instance.ExtendSession();
        }
