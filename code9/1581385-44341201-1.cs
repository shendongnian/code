    using AS.HDFql;
 
    public class Example
    {
        public static void Main(string []args)
        {
            int datatype;
            // create an HDF file named "example.h5" and use (i.e. open) it
            HDFql.Execute("CREATE FILE example.h5");
            HDFql.Execute("USE FILE example.h5");
            // create an attribute named "attrib" of type float
            HDFql.Execute("CREATE ATTRIBUTE attrib AS FLOAT");
            // get datatype of attribute "attrib" and populate HDFql default cursor with it
            HDFql.Execute("SHOW DATATYPE attrib");
            // move HDFql default cursor to first position
            HDFql.CursorFirst();
            // retrieve datatype from HDFql default cursor
            datatype = (int) HDFql.CursorGetInt();
            // print message according to datatype
            if (datatype == HDFql.TinyInt || datatype == HDFql.VarTinyInt)
                System.Console.WriteLine("Datatype is a char");
            else if (datatype == HDFql.UnsignedTinyInt || datatype == HDFql.UnsignedVarTinyInt)
                System.Console.WriteLine("Datatype is an unsigned char");
            else if (datatype == HDFql.SmallInt || datatype == HDFql.VarSmallInt)
                System.Console.WriteLine("Datatype is a short");
            else if (datatype == HDFql.UnsignedSmallInt || datatype == HDFql.UnsignedVarSmallInt)
                System.Console.WriteLine("Datatype is an unsigned short");
            else if (datatype == HDFql.Int || datatype == HDFql.VarInt)
                System.Console.WriteLine("Datatype is an int");
            else if (datatype == HDFql.UnsignedInt || datatype == HDFql.UnsignedVarInt)
                System.Console.WriteLine("Datatype is an unsigned int");
            else if (datatype == HDFql.BigInt || datatype == HDFql.VarBigInt)
                System.Console.WriteLine("Datatype is a long long");
            else if (datatype == HDFql.UnsignedBigInt || datatype == HDFql.UnsignedVarBigInt)
                System.Console.WriteLine("Datatype is an unsigned long long");
            else if (datatype == HDFql.Float || datatype == HDFql.VarFloat)
                System.Console.WriteLine("Datatype is a float");
            else if (datatype == HDFql.Double || datatype == HDFql.VarDouble)
                System.Console.WriteLine("Datatype is a double");
            else if (datatype == HDFql.Char || datatype == HDFql.VarChar)
                System.Console.WriteLine("Datatype is a char");
            else if (datatype == HDFql.Opaque)
                System.Console.WriteLine("Datatype is an opaque");
            else
                System.Console.WriteLine("Unknown datatype");
        }
    }
