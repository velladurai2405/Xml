using System;
using System.Collections.Generic;
using System.Xml;
namespace XmlApplication;
class Program
{
    static void Main(string[] args)
    {
        DinnerMenu dinnerMenu = new DinnerMenu();

        // Load the XML file
        using (XmlReader reader = XmlReader.Create("FoodCatelog4.xml"))
        {
            while (reader.Read())
            {
                // Check if the current node is an element node and its name is "food"
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "food")
                {
                    // Read attributes
                    int orderId = Convert.ToInt32(reader.GetAttribute("orderid"));
                    int isVeg = Convert.ToInt32(reader.GetAttribute("veg"));

                    // Initialize variables to store food details
                    string name = null, price = null, description = null;
                    int calories = 0;

                    // Read child elements
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            switch (reader.Name)
                            {
                                case "name":
                                    name = reader.ReadElementContentAsString();
                                    break;
                                case "price":
                                    price = reader.ReadElementContentAsString();
                                    break;
                                case "description":
                                    description = reader.ReadElementContentAsString();
                                    break;
                                case "calories":
                                    calories = reader.ReadElementContentAsInt();
                                    break;
                            }
                        }

                        // Exit the loop when the end element of "food" is reached
                        if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "food")
                            break;
                    }

                    // Create FoodDetails instance
                    FoodDetails details = new FoodDetails
                    {
                        Name = name,
                        Price = double.Parse(price.TrimStart('$')),
                        Description = description,
                        Calories = calories
                    };

                    // Add food to dinner menu
                    dinnerMenu.AddFood(orderId, isVeg, details);
                }
            }
        }

        // Output the dinner menu
        foreach (Food food in dinnerMenu.Foods)
        {
            Console.WriteLine("Order: " + food.OrderID);
            Console.WriteLine("Is Veg: " + food.IsVeg);
            Console.WriteLine("Name: " + food.Details.Name);
            Console.WriteLine("Price: " + food.Details.Price);
            Console.WriteLine("Description: " + food.Details.Description);
            Console.WriteLine("Calories: " + food.Details.Calories);
            Console.WriteLine();
        }
        dinnerMenu.WriteToXml("new_dinner_menu.xml");
    }
}