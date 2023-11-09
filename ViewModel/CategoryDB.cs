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
        }

        protected override BaseEntity NewEntity()
        {
            return new Category();
        }
    }
}
