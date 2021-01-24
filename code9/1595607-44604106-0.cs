        Dim xe As XElement
        ' to load from a file
        ' Dim yourpath As String = "your path here"
        'xe = XElement.Load(yourpath)
        ' for testing
        xe = <OrderData>
                 <Order OrderID="OR00001">
                     <OrderDate>26 May 2017</OrderDate>
                     <BuyerID>WCS1810001</BuyerID>
                     <Instructions>Place item carefully</Instructions>
                     <Items ItemID="IT00001">
                         <ItemName>ASUS Monitor</ItemName>
                         <Description>Best monitor in the world</Description>
                         <Category>Monitor</Category>
                         <Quantities>100</Quantities>
                         <Manufacturer>ASUS</Manufacturer>
                         <UnitPrice>$100.00</UnitPrice>
                     </Items>
                 </Order>
             </OrderData>
        Dim item As XElement
        'this does not find an item
        item = (From el In xe...<Items>
                Where el.@ItemID = "IT"
                Select el).FirstOrDefault
        If item Is Nothing Then Stop
        'this finds the item
        item = (From el In xe...<Items>
                Where el.@ItemID = "IT00001"
                Select el).FirstOrDefault
        'add a new item to the order.  an item prototype
        Dim itmProto As XElement = <Items ItemID="">
                                       <ItemName></ItemName>
                                       <Description></Description>
                                       <Category></Category>
                                       <Quantities></Quantities>
                                       <Manufacturer></Manufacturer>
                                       <UnitPrice></UnitPrice>
                                   </Items>
        Dim newItem As New XElement(itmProto) 'note that itmProto is not used directly, only as part of New
        newItem.@ItemID = "ITM0042"
        newItem.<ItemName>.Value = "FOO"
        newItem.<Description>.Value = "this is a test"
        'etc
        xe.<Order>.Last.Add(newItem) 'add to order
        ' to save file
        ' xe.Save(yourpath)
