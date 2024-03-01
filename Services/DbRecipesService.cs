using DC;
using Services.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Services
{
    public class DbRecipesService : RecipesService
    {
        public override List<Recipe> GetAll()
        {
            return GetAllFromDb("SelectRecipe", System.Data.CommandType.StoredProcedure);

            /**
             *  First aproach, with a query
             *  GetAllFromDb("SELECT * FROM Recipes ORDER BY Title", System.Data.CommandType.Text);
             */
        }

        protected List<Recipe> GetAllFromDb(String commandText, System.Data.CommandType commandType)
        {
            using (var cn = new SqlConnection("RecipesConnectionString".GetConnectionString()))
            {
                cn.Open();

                var recipes = new List<Recipe>();

                var cmd = cn.CreateCommand();
                cmd.CommandText = commandText;
                cmd.CommandType = commandType;

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
