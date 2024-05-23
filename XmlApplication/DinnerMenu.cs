using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XmlApplication
{
    public class DinnerMenu
    {
        public List<Food> Foods { get; set; }

    public DinnerMenu()
    {
        Foods = new List<Food>();
    }

    public void AddFood(int orderID, int isVeg, FoodDetails details)
    {
        Foods.Add(new Food { OrderID = orderID, IsVeg = isVeg, Details = details });
    }
        
    }
}