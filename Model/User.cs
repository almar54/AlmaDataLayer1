using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : BaseEntity
    {
        protected string firstName;
        protected string lastName;
        protected string userName;
        protected string password;
        protected City city;
        protected bool isManager;
        protected string email;
        protected string phoneNum;

        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string UserName { get { return userName; } set { userName = value; } }
        public string Password { get { return password; } set { password = value; } }
        public City City { get { return city; } set { city = value; } }
        public bool IsManager { get { return isManager; } set { isManager = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string PhoneNum { get { return phoneNum; } set { phoneNum = value; } }
    }
    public class UserList : List<User>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public UserList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public UserList(IEnumerable<User> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public UserList(IEnumerable<BaseEntity> list)
            : base(list.Cast<User>().ToList()) { }
    }
}
