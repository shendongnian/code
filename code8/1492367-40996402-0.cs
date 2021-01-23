    Uses [...], MSXML;
    procedure TForm1.FormCreate(Sender: TObject);
    var
      SS : TStringStream;
      MS : TMemoryStream;
      Output : AnsiString;
      i,
      j : Integer;
      XmlDoc: IXMLDOMDocument;
      NodeList : IXmlDOMNodeList;
      Attributes : IXMLDOMNamedNodeMap;
      AttrNode : IXmlDomNode;
    begin
      SS := TStringStream.Create('');
      MS := TMemoryStream.Create;
      try
        //  the following line is to work around a problem decoding the blob field
        //  which you get when the query returms the XML as a blob
        AdoQuery1.SQL.Text := 'select Convert(Text, (' + AdoQuery1.SQL.Text + '))';
        AdoQuery1.Open;
        TBlobField(AdoQuery1.Fields[0]).SaveToStream(SS);
        Output := SS.DataString;
        Memo1.Lines.Text := Output;
        //  As can be seen from the contents of Memo1, the contents of Output are not
        //  well-formed XML, just a series of nodes with the same name.  So, we surround them
        //  with a root node to make Output XML-parseable
        Output := '<data>' + Output + '</data>';
        XmlDoc := CoDOMDocument.Create;
        XmlDoc.Async := False;
        XmlDoc.LoadXml(Output);
        //  The following XPath query gets the data-row nodes of the XML
        NodeList := XmlDoc.documentElement.SelectNodes('/data/*');
        Assert(NodeList <> Nil);
        Memo1.Lines.BeginUpdate;
        Memo1.Lines.Clear;
        for i := 0 to NodeList.Length - 1 do begin
          Memo1.Lines.Add('Row');
          Attributes := NodeList.item[I].Attributes;
          for j := 0 to Attributes.length - 1 do begin
            Memo1.Lines.Add('Field');
            AttrNode := Attributes.item[j];
            Memo1.Lines.Add(AttrNode.nodeName + ': ' + AttrNode.nodeValue);
            Memo1.Lines.Add('');
          end;
        end;
      finally
        Memo1.Lines.EndUpdate;
        XmlDoc := Nil;
        SS.Free;
        MS.Free;
      end;
    end;
