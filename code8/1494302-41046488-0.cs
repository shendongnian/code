            EstaOcupado = true;
            var taskSalvar = Task.Run(() =>
            {
                var proxyFactory = ServiceLocator.Current.GetInstance<IServiceClientFactory>();
                var proxy = proxyFactory.GetCadastrosGeraisService();
                proxy.Open();
                caixa = Boot.Mapeador.Map<CaixaModel, Caixa>(Caixa);
                caixa = proxy.SalvarCaixa(caixa);
                proxy.Close();
            });
            try
            {
                taskSalvar.Wait();
                Caixa.EndEdit();
                EstaEmEdicao = false;
            }
            catch (AggregateException ae)
            {
                var msg = WcfProxy.HandleServiceExceptions(ae);
                Resolve<IMessageVisualizer>()
                    .Show("Atenção", msg,
                        new CustomMessageVisualizerOptions() {Dialog = DialogType.Alert, Prompt = MessageButtons.OK});
            }
            finally
            {
                EstaOcupado = false;
                Caixa = Boot.Mapeador.Map<Caixa, CaixaModel>(caixa);
            }
