    using NUnit.Framework;
    using Heleonix.Testing.NUnit.Aaa;
    using static Heleonix.Testing.NUnit.Aaa.AaaSpec;
    [ComponentTest(Type = typeof(Connector))]
    public static class ConnectorTests
    {
        [MemberTest(Name = nameof(Connector.Connect))]
        public static void Connect()
        {
            Connector connector = null;
            Arrange(() =>
            {
                connector = new Connector();
            });
            When("the Connect is called", () =>
            {
                Act(() =>
                {
                     connector.Connect(options);
                });
                And("the Connector is disconnected", () =>
                {
                    Arrange(() =>
                    {
                         connector.Disconnect();
                    });
                });
                Should("change the status to Disconnected", () =>
                {
                    Assert.That(connector.Disconnected, Is.True);
                });
            });
        }
    }
