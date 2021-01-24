    private DerivedT Read2_DerivedT(bool isNullable, bool checkType)
    {
        // [Code that uses isNullable and checkType omitted...]
        DerivedT derivedT = new DerivedT();
        while (this.Reader.MoveToNextAttribute())
        {
            if (!this.IsXmlnsAttribute(this.Reader.Name))
                this.UnknownNode(derivedT);
        }
        this.Reader.MoveToElement();
        // [Code that reads child elements and populates derivedT.anInt omitted...]
        return derivedT;
    }
