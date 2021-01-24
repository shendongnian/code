    using Autofac;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Builder.Dialogs.Internals;
    using Microsoft.Bot.Builder.Tests;
    using Microsoft.Bot.Connector;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using pc.apm.bot.Dialogs;
    using pc.apm.bot.Services;
    using pc.apm.bot.tests.Interfaces;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    namespace pc.apm.bot.tests
    {
        [TestClass]
        public class Test_New_User_Dialog : DialogTestBase
        {
            [TestMethod]
            public async Task Test_method() => Assert.IsTrue(await Task.FromResult(true));
            [TestMethod]
            public async Task Create_New_user_Dialog()
            {
                var mockRootDialog = new Mock<IMessageRecievedDialog<IMessageActivity>>(MockBehavior.Loose);
                var mockApmService = new Mock<IApmService>(MockBehavior.Strict);
                mockApmService.Setup(m => m.CreateUserAsync(It.IsAny<string>()))
                              .Returns<string>(x => Task.FromResult("123-123"));
                var NewUserDialog = new NewUserDialog(mockApmService.Object, LangaugeCodes.en_US);
                var userEmail = "pawel.chooch@fake.com";
                mockRootDialog.Setup(d => d.StartAsync(It.IsAny<IDialogContext>()))
                              .Returns<IDialogContext>(
                                    context =>
                                    {
                                        context.Wait(mockRootDialog.Object.MessageRecievedAsync);
                                        return Task.CompletedTask;
                                    });
                mockRootDialog.Setup(d => d.MessageRecievedAsync(It.IsAny<IDialogContext>(), It.IsAny<IAwaitable<IMessageActivity>>()))
                              .Returns<IDialogContext, IAwaitable<IMessageActivity>>(async (context, message) =>
                              {
                                  var email = await message;
                                  await context.Forward(
                                      child: NewUserDialog,
                                      resume: async (c, r) =>
                                      {
                                          Assert.AreEqual("123-123", await r);
                                          c.Done<object>(null);
                                      },
                                      item: email.Text,
                                      token: CancellationToken.None);
                              });
            
                var toBot = DialogTestBase.MakeTestMessage();
                using (new FiberTestBase.ResolveMoqAssembly(mockRootDialog.Object, NewUserDialog))
                using (var container = Build(Options.MockConnectorFactory | Options.ScopedQueue, mockRootDialog.Object, NewUserDialog))
                using (var scope = DialogModule.BeginLifetimeScope(container, toBot))
                {
                    DialogModule_MakeRoot.Register(scope, () => mockRootDialog.Object);
                    var task = scope.Resolve<IPostToBot>();
                    toBot.Text = userEmail;
                    await task.PostAsync(toBot, CancellationToken.None);
                    var firstResponse = scope.Resolve<Queue<IMessageActivity>>().Dequeue();
                    Assert.IsTrue(firstResponse.Text.Equals("Looks as if you are a new user, let's get you started!"));
                    var secondResponse = scope.Resolve<Queue<IMessageActivity>>().Dequeue();
                    Assert.IsTrue(secondResponse.Text.Equals($"A user for {userEmail} has been provisioned in ALFABET"));
                }
            }
        }
    }
