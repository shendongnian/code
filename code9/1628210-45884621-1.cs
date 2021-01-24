        public void CreateTradeAPI(Trades trade)
        {
            trade.UserID =User.Identity.Name;
            _context.UsersTrades.Add(trade);
            _context.SaveChanges();
       }   
