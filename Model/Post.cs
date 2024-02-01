using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Post : BaseEntity 
    {
        protected string title;
        protected string description;
        protected DateTime postDate;
        protected User user;
        protected DateTime postTime;
        protected Category category;
        protected Event postEvent;
        protected City city;
        [DataMember]
        public string Title { get { return title; } set { title = value; } }
        [DataMember]
        public string Description { get { return description; } set { description = value; } }
        [DataMember]
        public DateTime PostDate { get { return postDate; } set { postDate = value; } }
        [DataMember]
        public User User { get { return user; } set { user = value; } }
        [DataMember]
        public DateTime PostTime { get { return postTime; } set { postTime = value; } }
        [DataMember]
        public Category Category { get { return category; } set { category = value; } }
        [DataMember]
        public Event Event { get { return postEvent; } set { postEvent = value; } }
        [DataMember]
        public City City { get { return city; } set { city = value; } }
    }
    [CollectionDataContract]
    public class PostList : List<Post>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public PostList() { }
        //המרה אוסף גנרי לרשימת ערים
        public PostList(IEnumerable<Post> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת ערים
        public PostList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Post>().ToList()) { }
    }
}
