	public enum SequenceName
	{
		TestSequence
	}
	public interface IUnitOfWork : IDisposable
	{
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		void Commit(SqlContextInfo contextInfo);
		int NextSequenceValue(SequenceName sequenceName);
	}
	public class UnitOfWork : MyDbContext, IUnitOfWork
	{
	...
        public void Commit(SqlContextInfo contextInfo)
        {
            using (var scope = Database.BeginTransaction())
            {
                SaveChanges();
                scope.Commit();
            }
        }
		public int NextSequenceValue(SequenceName sequenceName)
		{
			var result = new SqlParameter("@result", System.Data.SqlDbType.Int)
			{
				Direction = System.Data.ParameterDirection.Output
			};
			Database.ExecuteSqlCommand($"SELECT @result = (NEXT VALUE FOR [{sequenceName.ToString()}]);", result);
			return (int)result.Value;
		}
	...
	}
	internal class TestRepository
	{
		protected readonly IUnitOfWork UnitOfWork;
		private readonly DbSet<Test> _tests;
		public TestRepository(IUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
			_tests = UnitOfWork.Set<Test>();
		}
		public int CreateTestEntity(NewTest test)
		{
			var newTest = new Test
			{
				Id = UnitOfWork.NextSequenceValue(SequenceName.TestSequence),
				Name = test.Name
			};
			_tests.Add(newTest);
			return newTest.Id;
		}
	}
