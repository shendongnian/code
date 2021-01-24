        static float CalcMinWidth(IList<Entity> entities)
        {
            var count = entities.Count;
            List<Entity> local = new List<Entity>(count + 1);
            local.AddRange(entities);
            local.Add(new Entity(1, 0)); // add one that marks "end"
            local.Sort((e1, e2) => Comparer<float>.Default.Compare(e1.t, e2.t));
            float minReqW = 0;
            for (int i = 0; i < count; i++)
            {
                var e1 = local[i];
                var e2 = local[i + 1];
                var reqW = e1.width / (e2.t - e1.t);
                if (reqW > minReqW)
                    minReqW = reqW;
            }
            return minReqW;
        }
