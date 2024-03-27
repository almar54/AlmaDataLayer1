using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ServiceModel
{
    [ServiceContract]
    interface IUnity
    {
        [OperationContract] UserList GetAllUsers();
        [OperationContract] User Login(User user);
        [OperationContract] int InsertUser(User user);
        [OperationContract] int UpdateUser(User user);
        [OperationContract] int DeleteUser(User user);
        [OperationContract] bool IsUserNameFree(string username);

        [OperationContract] CategoryList GetAllCategories();
        [OperationContract] int InsertCategory(Category category);
        [OperationContract] int UpdateCategory(Category category);
        [OperationContract] int DeleteCategory(Category category);
        [OperationContract] bool IsCtgNameFree(string name);

        [OperationContract] CityList GetAllCities();
        [OperationContract] int InsertCity(City city);
        [OperationContract] int UpdateCity(City city);
        [OperationContract] int DeleteCity(City city);

        [OperationContract] EventList GetAllEvents();
        [OperationContract] int InsertEvent(Event _event);
        [OperationContract] int UpdateEvent(Event _event);
        [OperationContract] int DeleteEvent(Event _event);
        [OperationContract] bool IsEventNameFree(string name);

        [OperationContract] PostList GetAllPosts();
        [OperationContract] PostList GetPostsByDate(DateTime date);
        [OperationContract] int InsertPost(Post post);
        [OperationContract] int UpdatePost(Post post);
        [OperationContract] int DeletePost(Post post);
        [OperationContract] PostList GetPostsByUserId(int userId);
        #region Image
        [OperationContract] byte[] GetIamge(string fileName,string post);
        [OperationContract] void SaveImage(byte[] imageArray, string fileName);
        [OperationContract] string[] GetImagesByPost(string post);

        #endregion
    }
}
