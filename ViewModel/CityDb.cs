using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    class CityDb : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            throw new NotImplementedException();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            City city = entity as City;
            city.ID = int.Parse(reader["id"].ToString());
            city.Name = reader["cityName"].ToString();
            return city;
        }
        public CityList SelectAll()
        {
            command.CommandText = "SELECT * FROM tbCity";
            CityList list = new CityList(ExecuteCommand());
            return list;
        }
        public City SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tbCity WHERE id=" + id;
            CityList list = new CityList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];


        }
    }
}
