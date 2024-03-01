using DC;
using Services.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Services
{
    public class BdRecipesService : RecipesService
    {
        public override List<Recipe> GetAll()
        {
            using (var cn = new SqlConnection("RecipesConnectionString".GetConnectionString()))
            {
                cn.Open();

                var recipes = new List<Recipe>();

                var cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Recipe ORDER BY title";
                cmd.CommandType = System.Data.CommandType.Text;

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    recipes.Add(new Recipe()
                    {
                        Id = Guid.Parse(reader["id"].ToString()),
                        Title = reader["title"].ToString()
                    }
                    );
                }

                return recipes;
            }
        }
    }
}
