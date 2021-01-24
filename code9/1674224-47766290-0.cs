        public static bool MasterPlantDifferentFromDetailPlant(string mrNumber)
        {
            string masterPlant = t_MT_MTInfo.GetMaterialRequestPlant(mrNumber);
            List<string> detailPlants = t_MT_MTItem.GetPlants(mrNumber);
            return !detailPlants.All(x => string.Equals(masterPlant.Trim(), x.Trim(), StringComparison.OrdinalIgnoreCase));
        }
