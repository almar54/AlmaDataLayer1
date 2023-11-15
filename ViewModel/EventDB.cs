using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class EventDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Event myEvent = entity as Event;
            myEvent.ID = int.Parse(reader["eventId"].ToString());
            myEvent.Name = reader["eventName"].ToString();
            myEvent.Severity = int.Parse(reader["eventSeverity"].ToString());
            return myEvent;
        }

        protected override BaseEntity NewEntity()
        {
            return new Event();
        }
        public EventList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblEvents";
            EventList list = new EventList(ExecuteCommand());
            return list;
        }
        public Event SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblEvents WHERE id=" + id;
            EventList list = new EventList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            Event mEvent = entity as Event;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@eventId", mEvent.ID);
            command.Parameters.AddWithValue("@eventName", mEvent.Name);
            command.Parameters.AddWithValue("@eventSeverity", mEvent.Severity);
        }
        public int Insert(Event event1)
        {
            command.CommandText = "INSERT INTO tblEvents (eventName, eventSeverity) VALUES ('@eventName', '@eventSeverity')";
            LoadParameters(event1);
            return ExecuteCRUD();
        }
        public int Update(Event event1)
        {
            command.CommandText = "UPDATE tblEvents SET eventName = '@eventName', eventSeverity = '@eventSeverity' " +
                "WHERE (tblEvents.eventId = '@eventId')";
            LoadParameters(event1);
            return ExecuteCRUD();
        }
        public int Delete(Event event1)
        {
            command.CommandText = "DELETE FROM tblEvents WHERE (tblEvents.eventId = @eventId)";
            LoadParameters(event1);
            return ExecuteCRUD();
        }
    }
}
