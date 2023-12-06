using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
            user.ID = int.Parse(reader["id"].ToString());
            user.FirstName = reader["firstName"].ToString();
            user.LastName = reader["lastName"].ToString();
            user.UserName = reader["userName"].ToString();
            user.Password = reader["password"].ToString();
            user.IsManager = bool.Parse(reader["isManager"].ToString());
            user.Email = reader["Email"].ToString();
            user.PhoneNum = reader["phoneNum"].ToString();
            CityDb cityDb = new CityDb();
            int CityId = int.Parse(reader["City"].ToString());
            user.City = cityDb.SelectById(CityId);
            return user;
        }

        protected override BaseEntity NewEntity()
        {
            return new User();
        }
        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblUsers";
            UserList list = new UserList(ExecuteCommand());
            return list;
        }
        public User SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblUsers WHERE id=" + id;
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            User user = entity as User;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@userId", user.ID);
            command.Parameters.AddWithValue("@firstName", user.FirstName);
            command.Parameters.AddWithValue("@lastName", user.LastName);
            command.Parameters.AddWithValue("@userName", user.UserName);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@city", user.City);
            command.Parameters.AddWithValue("@isManager", user.IsManager);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@phoneNum", user.PhoneNum);
        }
        public int Insert(User user)
        {
            command.CommandText = "INSERT INTO tblUsers (firstName, lastName, userName, password, city, isManager, Email, phoneNum) " +
                "VALUES ('@firstName', '@lastName', '@userName', '@password', '@city', '@isManager', '@Email', '@phoneNum')";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int Update(User user)
        {
            command.CommandText = "UPDATE tblUsers SET firstName = '@firstName', lastName = '@lastName', userName = '@userName', " +
                "password = '@password', city = '@city', isManager = '@isManager', Email = '@Email', phoneNum = '@phoneNum' " +
                "WHERE (tblUsers.UserId = '@UserId')";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int Delete(User user)
        {
            command.CommandText = "DELETE FROM tblUsers WHERE (tblUsers.userId = @userId)";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public User Login(User user)
        {
            command.CommandText = $"SELECT * FROM tblUsers WHERE userName = @userName AND password = @password";
            LoadParameters(user);
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 1) return list[0];
            return null;
        }
    }
}
