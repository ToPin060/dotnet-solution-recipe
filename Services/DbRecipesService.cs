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

        public override List<Recipe> GetByTitle(string title)
        {
            return GetAllFromDb($"SelectRecipe", System.Data.CommandType.StoredProcedure, title);
        }

        protected List<Recipe> GetAllFromDb(String commandText, System.Data.CommandType commandType, String? title = null)
        {
            using (var cn = new SqlConnection("RecipesConnectionString".GetConnectionString()))
            {
                cn.Open();

                var recipes = new List<Recipe>();

                var cmd = cn.CreateCommand();
                cmd.CommandText = commandText;
                cmd.CommandType = commandType;

                if (!String.IsNullOrEmpty(title))
                {
                    cmd.Parameters.Add(new SqlParameter("@title", title));
                }

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
