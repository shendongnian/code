    class ctest : public CObject
    {
    public:
    	DECLARE_SERIAL(ctest)
    	CString name;
    	int i1, i2, i3;
    	void Serialize(CArchive& arc)
    	{
    		CObject::Serialize(arc);
    		if (arc.IsStoring())
    			arc << i1 << i2 << i3 << name;
    	}
    };
	ctest test;
	test.i1 = 1;
	test.i2 = 2;
	test.i3 = 3;
	test.name = L"ABC";
