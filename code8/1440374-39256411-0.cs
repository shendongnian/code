            //constraints avoiding the optimal solution 
            List<int> Restricoes = new List<int>();
            bool solucaoOtima = false;
            
            //index = 1, because the first constraint is always in the model
            int index = 1;
            while (solucaoOtima == false)
            {
                var restricao = auxModel.Constraints.ToList()[index];
                restricao.Enabled = false;
                auxSolution = auxContext.Solve();
                
                //that's the trick part, I assumed that if I find the optimal
                //solution by removing the current index, then I assumed
                //the problem was this index
                if (auxSolution.Quality.ToString().Equals("Optimal"))
                {
                    Restricoes.Add(index); 
                    VoltarRestricoes(auxModel, Restricoes);
                    
                    auxSolution = auxContext.Solve();
                    solucaoOtima =   auxSolution.Quality.ToString().Equals("Optimal") ? true : false;
                }
                index = index == limiteIteracao ? 1 : index + 1;
            }
        /// <summary>
        /// Reset all the constraints of the model, except those indexes that are in Restricoes list.
        /// </summary>
        /// <param name="auxModel"></param>
        /// <param name="Restricoes"></param>
        private void VoltarRestricoes(Model auxModel, List<int> Restricoes)
        {
            for (int i = 0; i < auxModel.Constraints.ToList().Count; i++)
            {
                var restricao = auxModel.Constraints.ToList()[i];
                restricao.Enabled = Restricoes.Contains(i) ? false : true;
            }
        }
       
