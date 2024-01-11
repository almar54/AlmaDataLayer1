using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ServiceModel
{
    public class UnityService : IUnity
    {
        public int DeleteCategory(Category category)
        {
            CategoryDB categoryDB = new CategoryDB();
            return categoryDB.Delete(category);
        }

        public int DeleteCity(City city)
        {
            CityDb cityDb = new CityDb();
            return cityDb.Delete(city);
        }

        public int DeleteEvent(Event _event)
        {
            EventDB eventDB = new EventDB();
            return eventDB.Delete(_event);
        }

        public int DeletePost(Post post)
        {
            PostDB postDB = new PostDB();
            return postDB.Delete(post);
        }

        public int DeleteUser(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Delete(user);
        }

        public CategoryList GetAllCategories()
        {
            CategoryDB categoryDB = new CategoryDB();
            return categoryDB.SelectAll();
        }

        public CityList GetAllCities()
        {
            CityDb cityDb = new CityDb();
            return cityDb.SelectAll();
        }

        public EventList GetAllEvents()
        {
            EventDB eventDB = new EventDB();
            return eventDB.SelectAll();
        }

        public PostList GetAllPosts()
        {
            PostDB postDB = new PostDB();
            return postDB.SelectAll();
        }

        public UserList GetAllUsers()
        {
            UserDB userDB = new UserDB();
            return userDB.SelectAll();
        }

        public int InsertCategory(Category category)
        {
            CategoryDB categoryDB = new CategoryDB();
            return categoryDB.Insert(category);
        }

        public int InsertCity(City city)
        {
            CityDb cityDb = new CityDb();
            return cityDb.Insert(city);
        }

        public int InsertEvent(Event _event)
        {
            EventDB eventDB = new EventDB();
            return eventDB.Insert(_event);
        }

        public int InsertPost(Post post)
        {
            PostDB postDB = new PostDB();
            return postDB.Insert(post);
        }

        public int InsertUser(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Insert(user);
        }

        public bool IsUserNameFree(string username)
        {
            UserDB db = new UserDB();
            UserList list = db.CheckUserName(username);
            return list.Count == 0;
        }

        public User Login(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Login(user);
        }

        public int UpdateCategory(Category category)
        {
            CategoryDB categoryDB = new CategoryDB();
            return categoryDB.Update(category);
        }

        public int UpdateCity(City city)
        {
            CityDb cityDb = new CityDb();
            return cityDb.Update(city);
        }

        public int UpdateEvent(Event _event)
        {
            EventDB eventDB = new EventDB();
            return eventDB.Update(_event);
        }

        public int UpdatePost(Post post)
        {
            PostDB postDB = new PostDB();
            return postDB.Update(post);
        }

        public int UpdateUser(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Update(user);
        }
    }
}
