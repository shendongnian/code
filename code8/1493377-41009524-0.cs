    string FooMyXObject( XObject bar ){
        if (bar.NodeType == NodeType.Element || bar.NodeType == NodeType.XAttribute)
            return ((dynamic)bar).Value;
        else
            throw new Exception( "Generic Fail Message" );
    }
