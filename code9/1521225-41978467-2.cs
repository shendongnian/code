        Dim persons As XElement
        persons = <persons>
                      <Person>
                          <Name>A</Name>
                          <Age>32</Age>
                      </Person>
                      <Person>
                          <Name>B</Name>
                          <Age>42</Age>
                          <Opt1>optional B1</Opt1>
                          <Opt2>optional B2</Opt2>
                      </Person>
                  </persons>
        Dim persList As New List(Of Person)
        For Each el As XElement In persons.Elements
            persList.Add(New Person(el))
        Next
