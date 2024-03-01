using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services
{
    public class XmlRecipesService : RecipesService
    {
        public override List<Recipe> GetAll()
        {
            XDocument xdoc = XDocument.Load("datas\\recipes.xml");
            var recipes = xdoc.Descendants("recipe")
                .Select(recipeElement => new Recipe
                {
                    Id = Guid.Parse(recipeElement.Attribute("id")?.Value),
                    Title = recipeElement.Attribute("title")?.Value
                })
                .ToList();

            return recipes;
        }
    }
}
