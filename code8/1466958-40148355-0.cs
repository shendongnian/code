    <?xml version="1.0" encoding="utf-8"?>
    <CodeSnippets
        xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
        <CodeSnippet Format="1.0.0">
            <Header>
                <Title>Properties with Dirty</Title>
                <Author>Myself</Author>
                <Description>Creates a property which ties to isDrty</Description>
                <Shortcut>propisd</Shortcut>
            </Header>
            <Snippet>
                <Code Language="C#">
                    <![CDATA[private $TYPE$ $PRIVATENAME$;
                        public $TYPE$ $PROPERTYNAME$
                        {
                            get { return $PRIVATENAME$; }
                            set 
                            {
                                if ($PRIVATENAME$ != value)
                                {
                                    $PRIVATENAME$ = value;
                                    _isDirty = true;
                                }
                            }
                        }]]>
                </Code>
                <Declarations>
                    <Literal>
                        <ID>TYPE</ID>
                        <ToolTip>replace with the type</ToolTip>
                        <Default>"TYPE"</Default>
                    </Literal>
                    <Literal>
                        <ID>PRIVATENAME</ID>
                        <ToolTip>replace with the private name</ToolTip>
                        <Default>"PRIVATENAME"</Default>
                    </Literal>
                    <Literal>
                        <ID>PROPERTYNAME</ID>
                        <ToolTip>replace with the property name</ToolTip>
                        <Default>"PROPERTYNAME"</Default>
                    </Literal>
                </Declarations>
            </Snippet>
        </CodeSnippet>
    </CodeSnippets>
