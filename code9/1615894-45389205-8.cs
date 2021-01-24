    void GenerateAndSaveXmlDocument() {
        // loading these classes are resource intensive and takes time
        // so load only once and pass down to the sub classes
        var _student = new ResourceIntensiveObject1();
        var _course = new ResourceIntensiveObject2();
        var _user = new ResourceIntensiveObject3();
        IGenerateXml clsGenerateSection1 = new GenerateSection1(_student, _course, _user);
        IGenerateXml clsGenerateSection2 = new GenerateSection2(_student, _course, _user);
        IGenerateXml clsGenerateSection3 = new GenerateSection3(_student, _course, _user);
        // code goes on for other 9 classes
        // generate, combine and save final xml
    }
