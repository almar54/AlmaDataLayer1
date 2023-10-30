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
            int cityId = int.Parse(reader["city"].ToString());
            user.City = cityDb.SelectById(cityId);
            return user;
        }

        protected override BaseEntity NewEntity()
        {
            return new User();
        }
    }
}
