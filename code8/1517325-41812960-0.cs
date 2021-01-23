    [TestClass]
    public class LegacyCodeTest {
        [TestMethod]
        public async Task TestExecuteReaderAsync() {
            //Arrange
            var mapping = new Dictionary<string, string> {
                {"Col1","abc"},
                {"Col2","def"}
            };
            var mockDataReader = new Mock<IDataReader>();
            mockDataReader
                .Setup(m => m[It.IsAny<string>()])
                .Returns<string>(col => mapping[col])
                .Verifiable();
            var mockDataAccess = new Mock<IDataAccess>();
            mockDataAccess
                .Setup(m => m.ExecuteReaderAsync("nameOfProcedure", It.IsAny<Parameters>(), It.IsAny<Action<System.Data.IDataReader>[]>()))
                .Returns(Task.FromResult<object>(null))
                .Callback((string s, Parameters p, Action<System.Data.IDataReader>[] a) => {
                    if (a != null && a.Length > 0) {
                        a.ToList().ForEach(callback => callback(mockDataReader.Object));
                    }
                })
                .Verifiable();
            var sut = new SUT(mockDataAccess.Object);
            //Act
            await sut.MUT(2);
            //Assert
            mockDataReader.Verify(m => m["Col1"]);
            mockDataReader.Verify(m => m["Col2"]);
        }
        public interface IDataAccess {
            Task ExecuteReaderAsync(string procedureName, Parameters procedureParameters, params Action<System.Data.IDataReader>[] actions);
        }
        public class Parameters { }
        public class CustomObject {
            public object Prop1 { get; set; }
            public object Prop2 { get; set; }
        }
        public class SUT {
            IDataAccess db;
            public SUT(IDataAccess dataAccess) {
                this.db = dataAccess;
            }
            public async Task MUT(int id) {
                var result = await GetCustomObject(id);
            }
            private async Task<CustomObject> GetCustomObject(int id) {
                CustomObject obj = null;
                await db.ExecuteReaderAsync("nameOfProcedure", null,
                dr => {
                    obj = new CustomObject() {
                        Prop1 = dr["Col1"],
                        Prop2 = dr["Col2"]
                    };
                });
                return obj;
            }
        }
    }
