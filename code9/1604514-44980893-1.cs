        public static void ReturnFromBuildCommand(this Mock<IQueryCommandBuilder> builder, IQueryCommand command, string query = null)
        {
            Expression<Func<IQueryCommandBuilder, IQueryCommand>> expressOfFunc = commandBuilder => (commandBuilder.BuildCommand(query ?? It.IsAny<string>()));
            var methodCall = expressOfFunc.Body as MethodCallExpression;
            var args = methodCall.Arguments.ToArray();
            var nodeType = args[0].NodeType;
            
            builder.Setup(expressOfFunc)
                .Returns(command);
        }
