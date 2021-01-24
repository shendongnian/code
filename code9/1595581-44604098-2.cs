    XmlSerializer serializer = new XmlSerializer(typeof(Ontology));
    
    StreamReader reader = new StreamReader(@"c:\temp\test.xml");
    Ontology ontology = (Ontology)serializer.Deserialize(reader);
    
    var students = from student in ontology.DataPropertyAssertion
                   select new Student()
                   {
                       Name = student.NamedIndividual,
                       TypeIRI = student.Literal.datatypeIRI,
                       Value = student.Literal.Value,
                       IRI = student.DataProperty.IRI,
                   };
    
    foreach (var item in students)
    {
        //Use here your list of students
    }
    
    reader.Close();
    
    reader.Dispose();
