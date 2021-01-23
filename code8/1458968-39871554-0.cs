	public class HtmlContent
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Text { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? LastEditDate { get; set; }
		public int CreatedById { get; set; }
		public int LastEditedById { get; set; }
		
		public ApplicationUser CreatedBy { get; set; }
		public ApplicationUser LastEditedBy { get; set; }
	}
	public HtmlContentService
	{
		public async Task Edit(int id, string name, string description, string text)
		{
			try
			{
				var content = await this.WithId(id);
				
				// no need to detach the object if you arent disposing the context
				//this.db.Entry(content).State = EntityState.Detached; 
				var currentDate = DateTime.UtcNow;
				var lastEditedBy = this.userProvider.GetCurrentUser();
				// these methods could just be moved into this method
				this.SetLastEditInfo(content, currentDate, lastEditedBy);
				this.UpdateHtmlContent(content, name, description, text);
				this.db.Entry(content).State = EntityState.Modified;
				await this.db.SaveChangesAsync();
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException ex)
			{
				var errors = ex.EntityValidationErrors;
				throw;
			}
		}
		private void SetLastEditInfo(
			HtmlContent content, 
			DateTime lastEditDate, 
			ApplicationUser lastEditedBy)
		{
			if ((lastEditDate.HasValue && lastEditedBy == null) || 
				(!lastEditDate.HasValue && lastEditedBy != null))
			{
				throw new InvalidOperationException(
					$"{nameof(lastEditDate)} and {nameof(lastEditedBy)} must be used together");
			}
			content.LastEditDate = lastEditDate;
			content.LastEditedBy = lastEditedBy;
		}
		private void UpdateHtmlContent(
			HtmlContent content, 
			string name, 
			string description, 
			string text)
		{
			content.Name = name;
			content.Description = description;
			content.Text = text;
		}
	}
