    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SQLite;
    using NLog;
    using System.Reflection;
    using System.Data.Entity;
    using Spire.Xls;
    using System.Data;
    using System.Collections;
    
    namespace DynamicEFLoading
    {
        class TestProgram
        {
            private static Logger logit = LogManager.GetCurrentClassLogger();
            static void Main()
            {
                DateTime dtStart = new DateTime(DateTime.Now.Ticks);
                DateTime dtStop = new DateTime();
                TestProgram s = new TestProgram();
                Utils u = new Utils();
                s.p("Starting at " + DateTime.Now.ToLongTimeString());
                // for this test, I leave this door open the whole time...
                using (MyDbContext ctx = new MyDbContext())
                {
                    //###########################################################################
                    //
                    // create a row in db each time run...
                    //
                    Random rnd = new Random();
                    // 
                    Child c1 = new DynamicEFLoading.Child();
                    // Age, Weight, Name all come from base class Person()
                    c1.PersonAge = rnd.Next(120);
                    c1.PersonWeight = rnd.Next(85, 300);
                    c1.PersonName = String.Format("{0} {1}", Utils.GenerateName(6), Utils.GenerateName(8));
                    s.p(String.Format("Created .Name: {0}", c1.PersonName));
                    //
                    c1.dChildBaz = rnd.NextDouble();
                    c1.iChildBar = rnd.Next(99999);
                    c1.sChildFoo = String.Format("{0}", Utils.GenerateName(10));
                    s.p(String.Format("Created .sParentFoo: {0}", c1.sChildFoo));
                    //
                    ctx.Children.Add(c1);
                    //_______________________________________________________
                    ctx.SaveChanges();
                    //###########################################################################
                    //
                    // in production, there would be no hard coding...
                    //
                    string fileLocation = @"C:\Users\<some user>\Desktop\test.xlsx";
                    //
                    // NOTE! Here I am specifying the only tab(ws name) in the wb. This is easily changed 
                    //      to access all tabs by index, using Worksheet ws = wb.Worksheets[index], and
                    //      a simple loop through them all. In my first test, I even verify the tab had
                    //      a corresponding table in DB before continuing... 
                    string tableName = "Child";
                    //----------------------------------------------------------
                    // freeSpire.xls
                    Workbook wb = new Workbook();
                    wb.LoadFromFile(fileLocation);
                    //----------------------------------------------------------
                    // see NOTE! just above...
                    Worksheet ws = wb.Worksheets[tableName];
                    //----------------------------------------------------------
                    // create a DataTable
                    DataTable dt = new DataTable(tableName);
                    // load it with data from whoile worksheet (ws)
                    dt = ws.ExportDataTable();
                    // from now on, we use DataTable-not spreadsheet
                    //----------------------------------------------------------
                    s.p(String.Format("wb.WorkSheets count: " + wb.Worksheets.Count));
                    s.p(String.Format("ws.Rows count: " + ws.Rows.Count()));
                    s.p(String.Format("dt.Rows.Count: " + dt.Rows.Count));
                    s.p(String.Format("dt.Name: " + dt.TableName));
                    //==========================================================
                    // getting assembly name programmatically fails when a project is inside a solution
                    //  in VS. It assumes ...\ProjName\ProjName\... whis isn't how solutions go... 
                    string pathToAssembly = @"C:\Users\<some user>\Documents\Visual Studio 2015\Projects\DynamicEFLoading\DynamicEFLoading\bin\Debug\DynamicEfLoading.exe";
                    // string pathToAssembly = @".\DynamicEfLoading.exe";
                    // create an 'anonymous', or ghost class:
                    var aClass = u.CreateInstanceOf(dt.TableName, pathToAssembly);
                    // display class type
                    s.p(String.Format("aClass.FullName: " + aClass.GetType().FullName));
                    //==========================================================
                    //
                    // creating a DbSet for the dt's entities. It isn't good enough to just create
                    //  the class itself-it needs to be from the DbContext (ctx). or else you can't
                    //  ctx.SaveChanges();    
                    //
                    s.p(String.Format("Creating 'dbs' object..."));
                    DbSet dbs = ctx.Set(aClass.GetType());
                    // But you can't att attributes/properties to a DbSet-only to the class it is
                    //  derived from, so we then use the DbSet (dbs) for this class to create an
                    //  empty class that we can populate & later add to DB via ctx:
                    var theObj = dbs.Create(aClass.GetType());
                    // make sure it's the right one:
                    s.p(String.Format("GetType: " + theObj.GetType()));
                    //____________________________________________________________________________
                    int i = 0; // used to keep track of each column as we go through the dt
                    foreach (DataRow dr in dt.Rows) // each dr in the dt is a separate instance of the theObj class
                    {
                        s.p(String.Format("================= row =================================="));
                        i = 0; // I don't like to put var instantiation in a loop...
                        // each drItem is the content for the row (theObj)
                        foreach (string drItem in dr.ItemArray)
                        {
                            s.p(String.Format("================= col {0} ", i));
                            string entAttrName = dt.Columns[i].ToString();
                            string entAttrValue = dr[i].ToString();
                            // column (property) name:
                            s.p("[" + i + "] Item: " + entAttrName.ToString());
                            // the value of that property to load into this class' property
                            s.p("[" + i + "] Value: " + entAttrValue.ToString());
                            // which type of data is this property? (string, int32, double...)
                            // -also has data like if nullable, etc. of use in later refinements...
                            TypeInfo thisTypeInfo = theObj.GetType().GetTypeInfo();
                            // All details from the property to update/set:
                            PropertyInfo theProp = thisTypeInfo.GetProperty(entAttrName);
                            //___________________________________________________________________
                            // need to determine the property type, converting entAttrValuefrom string:
                            // good debugging info at this stage to see what we've discovered from the class dynamically at rn time...
                            s.p("theProp.DeclaringType.FullName of attr: " + theProp.DeclaringType.FullName);
                            s.p("theProp.GetSetMethod(true).ToString() of attr: " + theProp.GetSetMethod(true).ToString());
                            s.p("theProp.GetType().ToString() of attr: " + theProp.GetType().ToString());
                            s.p("theProp.Name of attr: " + theProp.Name);
                            s.p("theProp.PropertyType.ToString() of attr: " + theProp.PropertyType.ToString());
                            s.p("theProp.ReflectedType.ToString() of attr: " + theProp.ReflectedType.ToString());
                            s.p("theProp.ReflectedType.ToString() of attr: " + theProp.SetMethod.ReturnType.ToString());
                           /* update entAttrName with entAttrValue:
                            *
                            * At this point, my values in the DataTable are all strings, but the class itself 
                            *   stores that value as who-knows-what. So here I just parse out what kind it is from three
                            *   common types. In future, may need to add more, but for now, these are the big 4: 
                            * 
                            * String, Integer, DatTime, and Double
                            */
                            if (theProp.PropertyType.ToString() == "System.String")
                            {
                                theProp.SetValue(theObj, (String)entAttrValue);
                                logit.Debug("Set {0} value: {1}",
                                    theProp.PropertyType.ToString(),
                                    entAttrValue);
                            }
                            else if (theProp.PropertyType.ToString().Contains("System.Int32"))
                            {
                                theProp.SetValue(theObj, int.Parse(entAttrValue));
                                logit.Debug("Set {0} value: {1}",
                                    theProp.PropertyType.ToString(),
                                    entAttrValue);
                            }
                            else if (theProp.PropertyType.ToString().Contains("System.DateTime"))
                            {
                                IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
                                DateTime dTime = DateTime.Parse(entAttrValue, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                                theProp.SetValue(theObj, entAttrValue);
                                logit.Debug("Set {0} value: {1}",
                                    theProp.PropertyType.ToString(),
                                    entAttrValue);
                            }
                            else if (theProp.PropertyType.ToString().Contains("System.Double"))
                            {
                                theProp.SetValue(theObj, double.Parse(entAttrValue));
                                logit.Debug("Set {0} value: {1}",
                                    theProp.PropertyType.ToString(),
                                    entAttrValue);
                            }
                            else
                            {
                                logit.Error("Unexpected property type: {0} given. string value: {1}",
                                    theProp.PropertyType.ToString(),
                                    entAttrValue
                                );
                            }
                            i++; // increment column index...
                        } // end foreach (string drItem in dr.ItemArray...
                        // add class to context...
                        dbs.Add(theObj);
                        // to save one by one (each row):
                        ctx.SaveChanges();
                    } // end of foreach (DataRow dr in dt.Rows...
                      // or... to save as batch (at end of worksheet):
                      // ctx.SaveChanges();
                      //###########################################################################
                    dtStop = new DateTime(DateTime.Now.Ticks);
                    TimeSpan tsDuration = dtStop - dtStart;
                    s.p(String.Format("end... took {0} seconds.", tsDuration.TotalSeconds.ToString()));
                    Console.ReadKey();
                } // end using DbContext...
            }
            /*
             * Convenience; writes to both...
             * 
             */
            //private static void p(string message)
            private void p(string message)
            {
                logit.Info(message);
                Console.WriteLine(message);
            }
        }
    }
