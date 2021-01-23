    [TestClass]
    public class UnitTest11 {
        [TestMethod]
        public void TestMethod1() {
            //Arrange
            //fake data
            var list = Enumerable.Range(1, 10).Select(id => new Department { Id = id }).ToList();
            var mock = new Mock<IRepository<Department>>();
            mock
                .Setup(repo => repo.Get(
                    It.IsAny<Expression<Func<Department, bool>>>(),
                    null,
                    It.IsAny<string>())
                )
                .Returns(
                    (
                        Expression<Func<Department, bool>> filter,
                        Func<IQueryable<Department>, IOrderedQueryable<Department>> orderBy,
                        string includeProperties
                    ) => {
                        var func = filter.Compile();
                        var result = list.Where(func);
                        if (orderBy != null) {
                            result = orderBy(result.AsQueryable());
                        }
                        return result;
                    }
                );
            var sut = new MyClass(mock.Object);
            var departmentId = 2;
            //Act
            var actual = sut.GetDepartment(departmentId);
            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual, list[departmentId - 1]);
           
        }
        public class MyClass {
            private readonly IRepository<Department> _departmentRepository;
            public MyClass(IRepository<Department> repository) {
                this._departmentRepository = repository;
            }
            public Department GetDepartment(int departmentId) {
                Department targetDepartment = _departmentRepository.Get(department => department.Id == departmentId).FirstOrDefault();
                return targetDepartment;
            }
        }
        
        public class Department {
            public int Id { get; set; }
        }
        public interface IRepository<TEntity> {
            IEnumerable<TEntity> Get(
                Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                string includeProperties = ""
            );
        }
    }
