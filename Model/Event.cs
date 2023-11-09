using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Event : BaseEntity
    {
        protected string name;
        protected int severity;
        public string Name { get { return name; } set { name = value; } }
        public int Severity { get { return severity; } set { severity = value; } }
    }
    public class EventList : List<Event>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public EventList() { }
        //המרה אוסף גנרי לרשימת ערים
        public EventList(IEnumerable<Event> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת ערים
        public EventList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Event>().ToList()) { }
    }
}
