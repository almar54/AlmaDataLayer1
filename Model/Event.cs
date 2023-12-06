using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Event : BaseEntity
    {
        protected string name;
        protected int severity;
        [DataMember]
        public string Name { get { return name; } set { name = value; } }
        [DataMember]
        public int Severity { get { return severity; } set { severity = value; } }
    }
    [CollectionDataContract]
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
