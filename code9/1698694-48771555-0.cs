    <?xml version="1.0" encoding="utf-8"?>
    <CodeSnippets
        xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
        <CodeSnippet Format="1.0.0">
            <Header>
                <Title>Test Method</Title>
                <Author>Grek40</Author>
                <Description>Create a testmethod with initial body</Description>
                <Shortcut>test</Shortcut>
            </Header>
            <Snippet>
                <Declarations>
                    <Literal>
                        <ID>name</ID>
                        <ToolTip>Replace with the testmethod name</ToolTip>
                        <Default>TestMethod</Default>
                    </Literal>
                </Declarations>
                <Code Language="CSharp">
                    <![CDATA[
                    public static void $name$()
                    {
                        try
                        {
                            string loggerFileName = System.Reflection.MethodBase.GetCurrentMethod().Name.ToString();
                            
                            $end$
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadLine();
                        }
                    }]]>
                </Code>
            </Snippet>
        </CodeSnippet>
    </CodeSnippets>
