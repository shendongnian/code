    class Test
    {
        public static void Main()
        {
            var root = CreateModel(1, "Root", null, 0);
            var users = CreateModel(2, "Users", root, 0);
            var administration = CreateModel(3, "Administration", users, 0);
            var logs = CreateModel(4, "Logs", users, 1);
            var customers = CreateModel(5, "Customers", root, 0);
            var orders = CreateModel(6, "Orders", customers, 0);
            List<ModuloModel> list = new List<ModuloModel> {root, users, administration, logs, customers, orders};
            list.Sort(new ModuloModelComparer());
            foreach (var moduloModel in list)
            {
                Console.WriteLine(moduloModel.Nome);
            }
            Console.ReadLine();
        }
        private static ModuloModel CreateModel(int id, string Nome, ModuloModel moduloPai, int ordem)
        {
            var model = new ModuloModel {Id = id, Nome = Nome, IdModuloPai = moduloPai?.Id, ModuloPai = moduloPai, ModulosFilhos = new HashSet<ModuloModel>(), Ordem = ordem};
            moduloPai?.ModulosFilhos.Add(model);
            return model;
        }
    }
