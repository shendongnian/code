		class Child : Parent
		{
		   public override Context GetContext()
		   {
		       return new Context(false);
		   }
		   public override GetData()
		   {
		       var context = GetContext();
		       var result = Query(context);
		   }
           public new string GetData2()
		   {
		       var context = base.GetContext();
               return Query(context);
		   }
		}
