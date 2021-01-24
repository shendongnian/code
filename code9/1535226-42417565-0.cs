    [TestClass]
    public class UnitTest {
        [TestMethod]
        public void _Mock_Action_T_Without_Moq() {
            //Arrange
            var callbacks = new Dictionary<string, dynamic>();
            var messageHubMock = new MessageHubStub(callbacks);
            //Act
            var sut = new Sut(messageHubMock.Object);
            //Assert
            Assert.IsTrue(callbacks.Count == 2);
            Assert.IsNotNull(callbacks["Refresh"]);
            Assert.IsNotNull(callbacks["Cancel"]);
        }
        public class Sut {
            public Sut(IMessageHub MessageHub) {
                MessageHub.Subscribe<RefreshMessage>("Refresh", RefreshMethod);
                MessageHub.Subscribe<CancelMessage>("Cancel", CancelMethod);
            }
            private void CancelMethod(CancelMessage obj) {
                throw new NotImplementedException();
            }
            private void RefreshMethod(RefreshMessage obj) {
                throw new NotImplementedException();
            }
        }
        public class MessageHubStub : IMessageHub {
            private Dictionary<string, dynamic> callbacks;
            public MessageHubStub(Dictionary<string, dynamic> callbacks) {
                this.callbacks = callbacks;
            }
            public IMessageHub Object { get { return this; } }
            public void Subscribe<T>(string topic, Action<T> callback) {
                callbacks.Add(topic, callback);
            }
        }
        public interface IMessageHub {
            void Subscribe<T>(string topic, Action<T> callback);
        }
        public class MessageBase { }
        public class RefreshMessage : MessageBase { }
        public class CancelMessage : MessageBase { }
    }
