    <View>
    <Query>
       <Where>
          <Or>
             <Eq>
                <FieldRef Name='ClassName' />
                <Value Type='Text'>" + Label1.Text + "</Value>
             </Eq>
             <Or>
                <Eq>
                   <FieldRef Name='ClassName' />
                   <Value Type='Text'>" + Label2.Text + "</Value>
                </Eq>
                <Or>
                   <Eq>
                      <FieldRef Name='ClassName' />
                      <Value Type='Text'>" + Label3.Text + "</Value>
                   </Eq>
                   <Eq>
                      <FieldRef Name='ClassName' />
                      <Value Type='Text'>" + Label4.Text + "</Value>
                   </Eq>
                </Or>
             </Or>
          </Or>
       </Where>
    </Query>
    </View>
