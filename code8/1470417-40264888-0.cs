	public class FavoriteService
	{
		...
		
		public void ToggleFavourite(int productId, int userId)
		{
			using (context = new MyDbContext())
			{
				var fav = context.ProductFavorites
                    .SingleOrDefault(f => f.ProductId == productId && f.UserId == userId);
				
				if(fav != null)
				{
					context.ProductFavorites.Remove(fav);
				} 
				else 
				{
					context.ProductFavorites.Add(new ProductFavorite
					{
						ProductId = productId,
						UserId = userId
					});
				}
				
				context.SaveChanges();
			}
		}
		...
	}
