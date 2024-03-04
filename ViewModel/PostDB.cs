using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PostDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Post post = entity as Post;
            post.ID = int.Parse(reader["postId"].ToString());
            post.Title = reader["title"].ToString();
            post.Description = reader["description"].ToString();
            post.PostDate = (DateTime)(reader["postDate"]);
            UserDB userDb = new UserDB();
            int userId = int.Parse(reader["userId"].ToString());
            post.User = userDb.SelectById(userId);
            post.PostTime = (DateTime)(reader["postTime"]);
            CategoryDB categoryDb = new CategoryDB();
            int categoryId = int.Parse(reader["categoryId"].ToString());
            post.Category = categoryDb.SelectById(categoryId);
            EventDB eventDb = new EventDB();
            int eventId = int.Parse(reader["eventId"].ToString());
            post.Event = eventDb.SelectById(eventId);
            CityDb cityDb = new CityDb();
            int cityId = int.Parse(reader["city"].ToString());
            post.City = cityDb.SelectById(cityId);
            return post;
        }

        protected override BaseEntity NewEntity()
        {
            return new Post();
        }
        public PostList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblPost";
            PostList list = new PostList(ExecuteCommand());
            return list;
        }
        public Post SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblPost WHERE id=" + id;
            PostList list = new PostList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }


        protected override void LoadParameters(BaseEntity entity)
        {
            Post post = entity as Post;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@title", post.Title);
            command.Parameters.AddWithValue("@description", post.Description);
            command.Parameters.AddWithValue("@postDate", post.PostDate.ToString("dd/MM/yyyy hh:mm"));
            command.Parameters.AddWithValue("@userId", post.User.ID);
            command.Parameters.AddWithValue("@postTime", post.PostTime.ToString("dd/MM/yyyy hh:mm"));
            command.Parameters.AddWithValue("@categoryId", post.Category.ID);
            command.Parameters.AddWithValue("@eventId", post.Event.ID);
            command.Parameters.AddWithValue("@city", post.City.ID);
            command.Parameters.AddWithValue("@PostId", post.ID);
        }
        public int Insert(Post post)
        {
            command.CommandText = "INSERT INTO tblPost (title, description, postDate, userId, postTime, categoryId, eventId, city) " +
                "VALUES (@title, @description, @postDate, @userId, @postTime, @categoryId, @eventId, @city)";
            LoadParameters(post);
            return ExecuteCRUD();
        }
        public int Update(Post post)
        {
            command.CommandText = "UPDATE tblPost SET title = @title, description = @description, postDate = @postDate, " +
                "userId = @userId, postTime = @postTime, categoryId = @categoryId, eventId = @eventId, city = @city " +
                "WHERE (tblPost.PostId = @postId)";
            LoadParameters(post);
            return ExecuteCRUD();
        }
        public int Delete(Post post)
        {
            command.CommandText = "DELETE FROM tblPost WHERE (tblPost.PostId = @PostId)";
            LoadParameters(post);
            return ExecuteCRUD();
        }
    }
}
