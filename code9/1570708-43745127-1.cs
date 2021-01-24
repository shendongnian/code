		using Spring.Data.Common;
		using Spring.Data.Generic;
		protected virtual IDbParametersBuilder CreateDbParametersBuilder()
		{
			return new DbParametersBuilder(AdoTemplate.DbProvider);
		}
