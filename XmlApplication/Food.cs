using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XmlApplication
{
    public class Food
    {
        public int OrderID { get; set; }
    public int IsVeg { get; set; } // Changed from bool to int
    public FoodDetails Details { get; set; }
        
    }
}