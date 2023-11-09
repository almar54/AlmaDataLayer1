using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
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
        public string Title { get { return title; } set { title = value; } }
        public string Description { get { return description; } set { description = value; } }
        public DateTime PostDate { get { return postDate; } set { postDate = value; } }
        public User User { get { return user; } set { user = value; } }
        public DateTime PostTime { get { return postTime; } set { postTime = value; } }
        public Category Category { get { return category; } set { category = value; } }
        public Event Event { get { return Event; } set { Event = value; } }
        public City City { get { return city; } set { city = value; } }
    }
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
