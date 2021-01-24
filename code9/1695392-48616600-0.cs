	using System.Linq.Dynamic.Core;
	public class CompanyRepository
	{
		public async Task<IEnumerable<Company>> Get(string columns)
		{
		return await _dbSet.AsNoTracking().Select<Company>("new(" + columns + ")").ToListAsync();
		}
	}
