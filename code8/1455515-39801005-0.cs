        [TestMethod]
        public async Task SampleChain_While_Count()
        {
            var root =
                Chain
                .PostToChain()
                .Select(_ => (IReadOnlyList<string>)Array.Empty<string>())
                .While
                (
                    items => Chain
                                .Return(items)
                                .Select(i => i.Count < 3),
                    items => Chain
                                .Return(items)
                                .Select(i => $"question {i.Count}")
                                .PostToUser()
                                .WaitToBot()
                                .Select(a => items.Concat(new[] { a.Text }).ToArray())
                )
                .Select(items => string.Join(",", items))
                .PostToUser();
            using (var container = Build(Options.ResolveDialogFromContainer | Options.Reflection))
            {
                var builder = new ContainerBuilder();
                builder
                    .RegisterInstance(root)
                    .As<IDialog<object>>();
                builder.Update(container);
                await AssertScriptAsync(container,
                    "hello",
                    "question 0",
                    "A",
                    "question 1",
                    "B",
                    "question 2",
                    "C",
                    "A,B,C"
                    );
            }
        }
