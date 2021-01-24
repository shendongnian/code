    public class PostsStore {
        public async Task<List<Post>> GetPostsAsync() {
            var posts = new List<Post>();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var connection = new SqlConnection(connectionString)) {
                var command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "GetPosts";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync()) {
                    while (await reader.ReadAsync()) {
                        var post = new Post() {
                            PostId = (int)(reader["PostId"]),
                            Title = reader.SafeGetString("Title"),
                            Body = reader.SafeGetString("Body"),
                            SaveTitle = reader.SafeGetString("SaveTitle"),
                            SaveBody = reader.SafeGetString("SaveBody"),
                            Slug = reader.SafeGetString("Slug"),
                            State = reader.SafeGetString("State"),
                            IsPublished = (bool)(reader["IsPublished"]),
                            LastSaved = (DateTime)(reader["LastSaved"]),
                            CreateDate = (DateTime)(reader["CreateDate"])
                        };
                        posts.Add(post);
                    }
                }
            }
            return posts;
        }
    }
