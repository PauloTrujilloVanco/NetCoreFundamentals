using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id=1, Name="Pizza Renzo", Location="Playa del Carmen", Cuisine= CuisineType.Italian},
                new Restaurant { Id=2, Name="Carnes Garibaldi", Location="Guadalajara", Cuisine= CuisineType.Mexican},
                new Restaurant { Id=3, Name="Al Meraj", Location="Zapopan", Cuisine= CuisineType.Indian},

            };
        }


        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) ||
                   r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
