using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CategoryDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Category category = entity as Category;
            category.ID = int.Parse(reader["categoryId"].ToString());
            category.Name = reader["categoryName"].ToString();
            return category;
        }

        protected override BaseEntity NewEntity()
        {
            return new Category();
        }
        public CategoryList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblCategories";
            CategoryList list = new CategoryList(ExecuteCommand());
            return list;
        }
        public Category SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblCategories WHERE categoryId=" + id;
            CategoryList list = new CategoryList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            Category category = entity as Category;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@categoryName", category.Name);
            command.Parameters.AddWithValue("@categoryId", category.ID);
        }
        public int Insert(Category category)
        {
            command.CommandText = "INSERT INTO tblCategories (categoryName) VALUES (@category)";
            LoadParameters(category);
            return ExecuteCRUD();
        }
        public int Update(Category category)
        {
            command.CommandText = "UPDATE tblCategories SET categoryName = @categoryName WHERE (categoryId = @categoryId)";
            LoadParameters(category);
            return ExecuteCRUD();
        }
        public int Delete(Category category)
        {
            command.CommandText = "DELETE FROM tblCategories WHERE (tblCategories.categoryId = @categoryId)";
            LoadParameters(category);
            return ExecuteCRUD();
        }
        public CategoryList CheckName(string name)
        {
            command.CommandText = $"SELECT * FROM tblCategories" +
                $" WHERE (categoryName = '{name}')";
            CategoryList list = new CategoryList(base.ExecuteCommand());
            return list;
        }
    }
}
