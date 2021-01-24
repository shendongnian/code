	using System.Collections.Generic;
	namespace Test1
	{
		class TestClass
		{
			private Element[] elements = new Element[0];
			public void AddElement(Element element)
			{
				List<Element> list = new List<Element>(this.elements);
				list.Add(element);
				this.elements = list.ToArray();
			}
			public int HowMuch()
			{
				return elements.Length;
			}
		}
	}
