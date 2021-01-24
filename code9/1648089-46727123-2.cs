    [TestMethod]
    public async Task DialogTask_Forward()
    {
        var dialogOne = new Mock<IDialogFrames<string>>(MockBehavior.Loose);
        var dialogTwo = new Mock<IDialogFrames<string>>(MockBehavior.Loose);
        const string testMessage = "foo";
        dialogOne
            .Setup(d => d.StartAsync(It.IsAny<IDialogContext>()))
            .Returns<IDialogContext>(async context => { context.Wait(dialogOne.Object.ItemReceived); });
        dialogOne
            .Setup(d => d.ItemReceived(It.IsAny<IDialogContext>(), It.IsAny<IAwaitable<IMessageActivity>>()))
            .Returns<IDialogContext, IAwaitable<IMessageActivity>>(async (context, message) =>
            {
                var msg = await message;
                await context.Forward(dialogTwo.Object, dialogOne.Object.ItemReceived<string>, msg, CancellationToken.None);
            });
        dialogOne
            .Setup(d => d.ItemReceived(It.IsAny<IDialogContext>(), It.IsAny<IAwaitable<string>>()))
            .Returns<IDialogContext, IAwaitable<string>>(async (context, message) =>
            {
                var msg = await message;
                Assert.AreEqual(testMessage, msg);
                context.Wait(dialogOne.Object.ItemReceived);
            });
        dialogTwo
            .Setup(d => d.StartAsync(It.IsAny<IDialogContext>()))
            .Returns<IDialogContext>(async context => { context.Wait(dialogTwo.Object.ItemReceived); });
        dialogTwo
            .Setup(d => d.ItemReceived(It.IsAny<IDialogContext>(), It.IsAny<IAwaitable<IMessageActivity>>()))
            .Returns<IDialogContext, IAwaitable<IMessageActivity>>(async (context, message) =>
            {
                var msg = await message;
                context.Done(msg.Text);
            });
        Func<IDialog<object>> MakeRoot = () => dialogOne.Object;
        var toBot = MakeTestMessage();
        using (new FiberTestBase.ResolveMoqAssembly(dialogOne.Object, dialogTwo.Object))
        using (var container = Build(Options.None, dialogOne.Object, dialogTwo.Object))
        {
            using (var scope = DialogModule.BeginLifetimeScope(container, toBot))
            {
                DialogModule_MakeRoot.Register(scope, MakeRoot);
                var task = scope.Resolve<IPostToBot>();
                toBot.Text = testMessage;
                await task.PostAsync(toBot, CancellationToken.None);
                dialogOne.Verify(d => d.StartAsync(It.IsAny<IDialogContext>()), Times.Once);
                dialogOne.Verify(d => d.ItemReceived(It.IsAny<IDialogContext>(), It.IsAny<IAwaitable<IMessageActivity>>()), Times.Once);
                dialogOne.Verify(d => d.ItemReceived(It.IsAny<IDialogContext>(), It.IsAny<IAwaitable<string>>()), Times.Once);
                dialogTwo.Verify(d => d.StartAsync(It.IsAny<IDialogContext>()), Times.Once);
                dialogTwo.Verify(d => d.ItemReceived(It.IsAny<IDialogContext>(), It.IsAny<IAwaitable<IMessageActivity>>()), Times.Once);
            }
        }
    }
