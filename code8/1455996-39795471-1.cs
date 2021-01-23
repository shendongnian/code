    private async void CompileAndExecuteLine(string userCode)
        {
            string output = "";
            ScriptOptions scriptOptions = ScriptOptions.Default.WithReferences(typeof(MyClass).Assembly);
            try
            {
                output = await CSharpScript.EvaluateAsync<string>(userCode, scriptOptions);
            }
            catch (CompilationErrorException cee)
            {
                string message = "You got errors:" + "\r\n";
                foreach (Diagnostic dia in cee.Diagnostics)
                {
                    message += dia.ToString() + "\r\n";
                }
                MessageBox.Show(message, "Compilation Error");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return output;
        }
