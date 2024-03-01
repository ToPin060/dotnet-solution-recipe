using DC;
using System.Collections.Generic;

namespace Services
{
    public abstract class RecipesService
    {
        public abstract List<Recipe> GetAll();
    }
}
