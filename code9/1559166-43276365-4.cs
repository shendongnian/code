    [TestMethod]
    public void _MyTestMethod() {
        //Arrange
        var expectedProtocolId = 1;
        var protocolsList = new List<PROTOCOL> {
            new PROTOCOL {
                PROTOCOL_ID = expectedProtocolId,
                USER_DEFINED_ID = "Some user defined Id"
            },
            new PROTOCOL {
                PROTOCOL_ID = 2,
                USER_DEFINED_ID = "Some other user defined Id"
            }
        };
        var unitOfWorkRBMMock = new Mock<IUnitOfWorkRBM>();
        unitOfWorkRBMMock
            .Setup(_ => _.ProtocolRepository.FindAll(It.IsAny<Expression<Func<PROTOCOL, bool>>>(), It.IsAny<Expression<Func<PROTOCOL, object>>[]>()))
            .Returns<Expression<Func<PROTOCOL, bool>>, Expression<Func<PROTOCOL, object>>[]>((expr, includes) => protocolsList.Where(expr.Compile()));
        var sut = new SUT(unitOfWorkRBMMock.Object);
        //Act
        var result = sut.GetProtocolById(expectedProtocolId);
        //Assert
        Assert.IsNotNull(result);
    }
    class SUT {
        private IUnitOfWorkRBM UnitOfWork;
        public SUT(IUnitOfWorkRBM unitOfWorkRBM) {
            this.UnitOfWork = unitOfWorkRBM;
        }
        public SelectListItem GetProtocolById(int protocolId) {
            var protocol = UnitOfWork.ProtocolRepository.FindAll(s => s.PROTOCOL_ID == protocolId).FirstOrDefault();
            return new SelectListItem() {
                Text = protocol.USER_DEFINED_ID,
                Value = protocolId.ToString()
            };
        }
    }
    public interface IUnitOfWorkRBM {
        IRepository<PROTOCOL> ProtocolRepository { get; set; }
    }
    public interface IRepository<TEntity> {
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
    }
    public class PROTOCOL {
        public int PROTOCOL_ID { get; set; }
        public string USER_DEFINED_ID { get; set; }
    }
