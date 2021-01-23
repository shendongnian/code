    <?xml version="1.0" encoding="utf-8" ?>
    <CodeSnippets  xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
    	<CodeSnippet Format="1.0.0">
    		<Header>
    			<Title>RelayCommand</Title>
    			<Shortcut>RelayCommand</Shortcut>
    			<Description>Code snippet for usage of the Relay Command pattern</Description>
    			<Author>Mat</Author>
    			<SnippetTypes>
    				<SnippetType>Expansion</SnippetType>
    			</SnippetTypes>
    		</Header>
    		<Snippet>
    			<Declarations>
    				<Literal>
    					<ID>name</ID>
    					<ToolTip>Name of the command</ToolTip>
    					<Default>Save</Default>
    				</Literal>
    			</Declarations>
    			<Code Language="csharp">
    				<![CDATA[	private RelayCommand _$name$Command;
    		public ICommand $name$Command
    		{
    			get
    			{
    				if (_$name$Command == null)
    				{
    					_$name$Command = new RelayCommand(param => this.$name$(param),
    						param => this.Can$name$(param));
    				}
    				return _$name$Command;
    			}
    		}
    
    		private bool Can$name$(object param)
    		{
    			return true;
    		}
    
    		private void $name$(object param)
    		{
                MessageServiceHelper.RegisterMessage(new NotImplementedException());
    		}]]>
    			</Code>
    		</Snippet>
    	</CodeSnippet>
    </CodeSnippets>
