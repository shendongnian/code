    BytesRef bytes = new BytesRef(NumericUtils.BUF_SIZE_INT32);
    NumericUtils.Int32ToPrefixCoded(64, 0, bytes);
    Term term = new Term("height", bytes);
    // var oQuery = new TermQuery(term);
    
    var oQuery = new BooleanQuery
    {
    	{ new TermQuery(new Term("name", "John")), Occur.SHOULD },
    	{ new TermQuery(term), Occur.SHOULD }
    };
