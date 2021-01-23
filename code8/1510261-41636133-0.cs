    [Serializable]
    public class Ejecucion2 : MarshalByRefObject, IJobExecution
    {
        public void SqlExecute()
        {
            Console.WriteLine("Here I execute the SQL");
        }
    }
