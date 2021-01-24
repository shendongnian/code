    <?xml version="1.0" encoding="utf-8"?>
    <CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
      <CodeSnippet Format="1.0.0">
        <Header>
          <SnippetTypes>
            <SnippetType>Expansion</SnippetType>
          </SnippetTypes>
          <Title>DependencyProperty</Title>
          <Author>will</Author>
          <Description>DependencyProperty
          </Description>
          <HelpUrl>
          </HelpUrl>
          <Shortcut>dp</Shortcut>
        </Header>
        <Snippet>
          <Declarations>
            <Literal Editable="true">
              <ID>PropName</ID>
              <ToolTip>Property name</ToolTip>
              <Default>PropertyName</Default>
              <Function>
              </Function>
            </Literal>
            <Literal Editable="false">
              <ID>ClassName</ID>
              <ToolTip>Class name</ToolTip>
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
              <ID>DefaultValue</ID>
              <ToolTip>Default value</ToolTip>
              <Default>null</Default>
              <Function>
              </Function>
            </Literal>
          </Declarations>
          <Code Language="csharp"><![CDATA[#region $PropName$
    /// <summary>
    /// The <see cref="DependencyProperty"/> for <see cref="$PropName$"/>.
    /// </summary>
    public static readonly DependencyProperty $PropName$Property =
        DependencyProperty.Register(
    		$PropName$PropertyName, 
    		typeof($Type$), 
    		typeof($ClassName$), 
    		new UIPropertyMetadata($DefaultValue$, On$PropName$PropertyChanged));
    
    /// <summary>
    /// Called when the value of <see cref="$PropName$Property"/> changes on a given instance of <see cref="$ClassName$"/>.
    /// </summary>
    /// <param name="d">The instance on which the property changed.</param>
    /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
    private static void On$PropName$PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as $ClassName$).On$PropName$Changed(e.OldValue as $Type$, e.NewValue as $Type$);
    }
    
    /// <summary>
    /// Called when <see cref="$PropName$"/> changes.
    /// </summary>
    /// <param name="oldValue">The old value</param>
    /// <param name="newValue">The new value</param>
    private void On$PropName$Changed($Type$ oldValue, $Type$ newValue)
    {
        ;
    }
    
    /// <summary>
    /// The name of the <see cref="$PropName$"/> <see cref="DependencyProperty"/>.
    /// </summary>
    public const string $PropName$PropertyName = "$PropName$";
    
    /// <summary>
    /// $end$
    /// </summary>
    public $Type$ $PropName$
    {
        get { return ($Type$)GetValue($PropName$Property); }
        set { SetValue($PropName$Property, value); }
    }
    #endregion  ]]></Code>
        </Snippet>
      </CodeSnippet>
    </CodeSnippets>
