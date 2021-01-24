        public override void Up()
        {
            CreateTable(
                  "dbo.UserPost",
                  c => new
                  {
                      Id = c.Int(nullable: false, identity: true),
                      PostTitle = c.String(),
                      Contents = c.String(),
                  })
                  .PrimaryKey(t => t.Id);                
        }
