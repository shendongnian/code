    public class GenericListOfPersonsConverter : ITypeConverter<ListOfPersons, MyPersonObjectList>
    {
    	public MyPersonObjectList Convert(ListOfPersons source, MyPersonObjectList destination, ResolutionContext context)
    	{
            //Take 24 persons here
    		return new MyPersonObjectList(){MyPersonObjects = source.Persons.Take(24).Select(p => p.Name).ToList()};
    	}
    }
