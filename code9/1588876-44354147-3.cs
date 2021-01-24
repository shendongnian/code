        private void GridOnRowDataBound(object sender, GridViewRowEventArgs gridViewRowEventArgs)
        {
            RegisterAsyncTask(new PageAsyncTask(() => Bob(gridViewRowEventArgs)));
            HttpContext.Current.Response.Write($"b");
        }
        private async Task Bob(GridViewRowEventArgs gridViewRowEventArgs)
        {
            if (gridViewRowEventArgs.Row.RowType != DataControlRowType.DataRow)
                return;
            var localIndex = ++_index;
            HttpContext.Current.Response.Write($"starting #{localIndex} <br />");
            await Task.Delay(1000);
            HttpContext.Current.Response.Write($"exiting #{localIndex} <br />");
        }
