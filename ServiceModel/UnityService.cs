using Model;
using System;
using System.Collections.Generic;
using System.IO;
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

        public PostList GetPostsByDate(DateTime date)
        {
            PostDB postDB = new PostDB();
            PostList posts = postDB.SelectAll();
            PostList posts1 = new PostList();
            foreach(Post p in posts.FindAll(p => p.PostDate > date))
            {
                posts1.Add(p);
            }
            return posts1;
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
           int record= postDB.Insert(post);
            if (record == 0) return -1;
            int id= postDB.SelectAll().Last().ID;
            return id;
        }

        public int InsertUser(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Insert(user);
        }

        public bool IsCtgNameFree(string name)
        {
            CategoryDB db = new CategoryDB();
            CategoryList list = db.CheckName(name);
            return list.Count == 0;
        }

        public bool IsEventNameFree(string name)
        {
            EventDB db = new EventDB();
            EventList list = db.CheckName(name);
            return list.Count == 0;
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
        public PostList GetPostsByUserId(int userId)
        {
            PostDB postDB = new PostDB();
            return postDB.SelebtByUserId(userId);
        }



        #region Image
        public byte[] GetIamge(string fileName, string post)
        {
            //ViewModel הנחה: הקובץ קיים ושמור בתיקיית תמונות בתוך
            //הפרמטר כולל רק את שם הקובץ
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\ViewModel\Images\Posts\"+post+"\\" + fileName);
            byte[] imgArray = File.ReadAllBytes(path);
            return imgArray;
        }
        public void SaveImage(byte[] imageArray, string fileName)
        {
            MemoryStream stream = new MemoryStream(imageArray);
            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

            string localFilePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\ViewModel\Images\Posts\" + fileName);
            Directory.CreateDirectory(localFilePath.Substring(0,localFilePath.LastIndexOf("\\")));
            image.Save(localFilePath);
        }
        public string[] GetImagesByPost(string post)
        {
            string imageDirectory = Path.Combine(Environment.CurrentDirectory, @"..\..\..\ViewModel\Images\Posts\");
            DirectoryInfo directory = new DirectoryInfo(imageDirectory + post + "\\");
            if (!Directory.Exists(directory.FullName)) 
                return null;
            FileInfo[] files = directory.GetFiles("*.*");
            return files.Select(file => file.Name).ToArray();
        }


        #endregion
    }
}
