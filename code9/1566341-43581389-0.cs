    protected void ArticleFormView_ItemInserting( object sender, FormViewInsertEventArgs e )
    {
       string articleNo = e.Values[ "Number" ].ToString();
       // ...some other things...
       if ( this.ShouldUpdateInsteadOfInsert( articleNo ) ) // (property IsDeleted = true)
       {
           // cancel insert 
           e.Cancel = true; 
           using ( StoreEntities ctx = new StoreEntities() )
		   {
                // get "deleted" article
				var restoredArticle = ctx.Articles.First( i => i.Number == articleNo );
                // "restore" it
				restoredArticle.IsDeleted = false;
				var type = restoredArticle.GetType();
				foreach ( var propertyInfo in type.GetProperties() )
				{
					if ( propertyInfo.CanWrite )
					{
                        // ignore some values that should not be changed
						if ( propertyInfo.Name == "Number" || propertyInfo.Name == "IsDeleted" || propertyInfo.Name == "ID" || propertyInfo.Name == "EntityKey" )
							continue;
                        
                        // update other properties, handle non convertible types separately
						if ( propertyInfo.PropertyType == typeof( int ) )
							propertyInfo.SetValue( restoredArticle, e.Values[ propertyInfo.Name ] == null ? (int?)null : Convert.ToInt32( e.Values[ propertyInfo.Name ] ), null );
						else if ( propertyInfo.PropertyType == typeof( decimal ) )
							propertyInfo.SetValue( restoredArticle, e.Values[ propertyInfo.Name ] == null ? (decimal?)null : Convert.ToDecimal( e.Values[ propertyInfo.Name ] ), null );
						else
							propertyInfo.SetValue( restoredArticle, e.Values[ propertyInfo.Name ], null );
					}
				}
				ctx.SaveChanges();
			}
          return;
       }
    }
