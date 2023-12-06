using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CityDb : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            throw new NotImplementedException();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            City city = entity as City;
            city.ID = int.Parse(reader["cityId"].ToString());
            city.Name = reader["cityName"].ToString();
            return city;
        }
        public CityList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblCities";
            CityList list = new CityList(ExecuteCommand());
            return list;
        }
        public City SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblCities WHERE cityId=" + id;
            CityList list = new CityList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            City city = entity as City;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@cityName", city.Name);
            command.Parameters.AddWithValue("@cityId", city.ID);
        }
        public int Insert(City city)
        {
            command.CommandText = "INSERT INTO tblCities (cityName) VALUES ('@cityName')";
            LoadParameters(city);
            return ExecuteCRUD();
        }
        public int Update(City city)
        {
            command.CommandText = "UPDATE tblCities SET cityName = @cityName WHERE ID = @cityId";
            LoadParameters(city);
            return ExecuteCRUD();
        }
        public int Delete(City city)
        {
            command.CommandText = "DELETE FROM tblCities WHERE cityId =@cityId";
            LoadParameters(city);
            return ExecuteCRUD();
        }
    }
}
