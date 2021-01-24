Using Formatter.Format as suggest here: [Generating well-formatted syntax with Roslyn][1], removed the undesired white spaces.
            string textOutput;
            var sb = new StringBuilder();
            var result = generator.CompilationUnit(declarations);
            var formattedResult = Formatter.Format(result, workspace);
            using (StringWriter writer = new StringWriter(sb))
            {
                formattedResult.WriteTo(writer);
                textOutput = writer.ToString();
            }
