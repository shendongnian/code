    public class BuildingHandler
    {
        public static void LoadBuildingTests(TestHandler testHandler)
        {
            if (testHandler == null) throw ....
            var building = LoadBuilding();
            var tests = testHandler.LoadTests(building.Id);
            //....
        }
        //..
    }
