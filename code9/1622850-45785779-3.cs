        // Parses DOCTYPE declaration
        private bool ParseDoctypeDecl() {
            if ( dtdProcessing == DtdProcessing.Prohibit ) {
                ThrowWithoutLineInfo( v1Compat ? Res.Xml_DtdIsProhibited : Res.Xml_DtdIsProhibitedEx );
            }
