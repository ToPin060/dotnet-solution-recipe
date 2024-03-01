using DC;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ObjectRecipesService : RecipesService
    {
        public override List<Recipe> GetAll()
        {
            return new List<Recipe>()
            {
                new Recipe() {Id = Guid.NewGuid(), Title="Object Recipe 01" },
                new Recipe() {Id = Guid.NewGuid(), Title="Object Recipe 02" },
                new Recipe() {Id = Guid.NewGuid(), Title="Object Recipe 03" },
                new Recipe() {Id = Guid.NewGuid(), Title="Object Recipe 04" },
                new Recipe() {Id = Guid.NewGuid(), Title="Object Recipe 05" }
            };
        }
    }
}
