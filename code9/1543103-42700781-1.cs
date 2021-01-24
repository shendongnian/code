    <?xml version="1.0" encoding="utf-8"?>
    <CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
      <CodeSnippet Format="1.0.0">
        <Header>
          <SnippetTypes>
            <SnippetType>Expansion</SnippetType>
          </SnippetTypes>
          <AlternativeShortcuts>
            <Shortcut Value="rodp">Read Only Dependency Property</Shortcut>
          </AlternativeShortcuts>
          <Title>Readonly DependencyProperty</Title>
          <Author>Will Sullivan</Author>
          <Description>Readonly DependencyProperty</Description>
          <HelpUrl>
          </HelpUrl>
          <Shortcut>RODP</Shortcut>
        </Header>
        <Snippet>
          <References>
          </References>
          <Imports>
            <Import>
              <Namespace>System.Windows</Namespace>
            </Import>
          </Imports>
          <Declarations>
            <Literal Editable="false">
              <ID>ClassName</ID>
              <ToolTip>The class name</ToolTip>
              <Default>ClassName</Default>
              <Function>ClassName()</Function>
            </Literal>
            <Literal Editable="true">
              <ID>Type</ID>
              <ToolTip>Property type</ToolTip>
              <Default>object</Default>
              <Function>
              </Function>
            </Literal>
            <Literal Editable="true">
              <ID>PropName</ID>
              <ToolTip>Property name</ToolTip>
              <Default>PropertyName</Default>
              <Function>
              </Function>
            </Literal>
          </Declarations>
          <Code Language="csharp"><![CDATA[#region $PropName$
    /// <summary>
    /// The <see cref="DependencyPropertyKey"/> for $PropName$.
    /// </summary>
    private static readonly DependencyPropertyKey $PropName$Key 
        = DependencyProperty.RegisterReadOnly(
            $PropName$PropertyName, 
            typeof($Type$), 
            typeof($ClassName$), 
            new PropertyMetadata());
    		
    /// <summary>
    /// The <see cref="DependencyProperty"/> for $PropName$.
    /// </summary>
    public static readonly DependencyProperty $PropName$Property 
        = $PropName$Key.DependencyProperty;
    
    /// <summary>
    /// The name of the <see cref="$PropName$"/> <see cref="DependencyProperty"/>.
    /// </summary>
    public const string $PropName$PropertyName = "$PropName$";
    	
    /// <summary>
    /// $end$
    /// </summary>
    public $Type$ $PropName$
    {
        get { return ($Type$)GetValue($PropName$Property ); }
        private set { SetValue($PropName$Key, value); }
    }
    #endregion
    
    ]]></Code>
        </Snippet>
      </CodeSnippet>
    </CodeSnippets>
