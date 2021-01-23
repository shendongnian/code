    string FooMyXObject(XObject bar)
    {
       switch(bar.NodeType)
       {
          case NodeType.Element:
              return ( bar as XElement ).Value;
          case NodeType.XAttribute:
              return ( bar as XAttribute ).Value;
          default:
              throw new Exception( "Generic Fail Message" );
       }
    }
