    string url = "http://sharepointsite/";
    var context = new ClientContext(url);
    var query = @"
    <View>
    	<Query>
    		<Where>
    			<And>
    				<Eq>
    					<FieldRef Name='Completed' />
    					<Value Type='Boolean'>0</Value>
    				</Eq>
    				<Eq>
    					<FieldRef Name='AssignedTo' LookupId='True'/>
    					<Value Type='Lookup'>
    						<UserID/>
    					</Value>
    				</Eq>
    			</And>
    		</Where>
    	</Query>
    </View>";
    var camlQuery = new CamlQuery() { ViewXml = query };
    var list = context.Web.Lists.GetByTitle("Tasks");
    var items = list.GetItems(camlQuery);
    context.Load(items);
    context.ExecuteQuery();
