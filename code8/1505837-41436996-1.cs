        private async void xxx()
        {
            var makeTask = Task<string>.Factory.StartNew(() => pipe_server.messaging_server());
            await pipe_server.messaging_server();
            {
                dataGrid_logic.DataGridLoadTarget(makeTask.Result);
            }
        }
