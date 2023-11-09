using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category : BaseEntity
    {
        protected string name;
        public string Name { get { return name; } set { name = value; } }
    }
    public class CategoryList : List<Category>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public CategoryList() { }
        //המרה אוסף גנרי לרשימת ערים
        public CategoryList(IEnumerable<Category> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת ערים
        public CategoryList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Category>().ToList()) { }
    }
}
