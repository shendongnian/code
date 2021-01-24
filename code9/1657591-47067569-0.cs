		public void WriteToOutput(List<Person> list)
        {
            string outputFileName = "names-list.txt";
            try
            {
                // other stuff
				return true;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("List is Empty");
                return false;
            }
        }
		[TestMethod]
        public void WriteToOutput_NullableList_ThrowNullReferenceException()
        {
            //arrange
            FileWriter fw = new FileWriter();
            //act
			bool returnValue = fw.WriteToOutput(null);
			
            //assert
			Assert.IsFalse(returnValue);
        }
