            public void FillDataGridView(DataGridView dataGridView,  int height, int[] cellsImages, string query = "")
        {
            try
            {
                command = new MySqlCommand(query, connection); //Создаём запрос для поиска
                adapter = new MySqlDataAdapter(command); //Выполняем команду
                                                         //Для отображения в таблице
                DataTable table = new DataTable(); //Создаём таблицу
                adapter.Fill(table); //Вставляем данные при выполнении команды в таблицу
               
                Settings settings = new Settings();
                //настраиваем отображение таблицы
                settings.GetSettingDisplayTable(dataGridView, height);
                dataGridView.DataSource = table; //подключаем заполненную таблицу и отображаем
                //Для отображения картинки в DataGridView
                settings.GetViewImageInCellTable(dataGridView, cellsImages);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
