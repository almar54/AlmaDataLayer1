using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
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

        [DataMember]
        public string FirstName { get { return firstName; } set { firstName = value; } }
        [DataMember]
        public string LastName { get { return lastName; } set { lastName = value; } }
        [DataMember]
        public string UserName { get { return userName; } set { userName = value; } }
        [DataMember]
        public string Password { get { return password; } set { password = value; } }
        [DataMember]
        public City City { get { return city; } set { city = value; } }
        [DataMember]
        public bool IsManager { get { return isManager; } set { isManager = value; } }
        [DataMember]
        public string Email { get { return email; } set { email = value; } }
        [DataMember]
        public string PhoneNum { get { return phoneNum; } set { phoneNum = value; } }
    }
    [CollectionDataContract]
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
