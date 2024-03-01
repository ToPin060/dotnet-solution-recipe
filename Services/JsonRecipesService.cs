using DC;
using System.Collections.Generic;
using System.IO;


namespace Services
{
    public class JsonRecipesService : RecipesService
    {
        public override List<Recipe> GetAll()
        {
            var json = File.ReadAllText("Data\\recipes.json");
            return (Newtonsoft.Json.JsonConvert.DeserializeObject<List<Recipe>>(json));
        }

        public override List<Recipe> GetByTitle(string title)
        {
            throw new System.NotImplementedException();
        }
    }
}
