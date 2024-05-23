using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

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

     public void WriteToXml(string filePath)
    {
        // Create an XmlWriterSettings object with appropriate settings
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;  // Indent the XML for readability

        // Create an XmlWriter for writing to the file
        using (XmlWriter writer = XmlWriter.Create(filePath, settings))
        {
            // Write the start element for the dinner menu
            writer.WriteStartElement("dinnermenu");

            // Write each food item
            foreach (Food food in Foods)
            {
                writer.WriteStartElement("food");
                writer.WriteAttributeString("order", food.OrderID.ToString());
                writer.WriteAttributeString("veg", food.IsVeg.ToString());

                writer.WriteElementString("name", food.Details.Name);
                writer.WriteElementString("price", food.Details.Price.ToString("C")); // Format price as currency
                writer.WriteElementString("description", food.Details.Description);
                writer.WriteElementString("calories", food.Details.Calories.ToString());

                writer.WriteEndElement(); // Close food element
            }

            // Write the end element for the dinner menu
            writer.WriteEndElement();
            Console.WriteLine("New dinner menu has been written to 'new_dinner_menu.xml'.");
        }
    }
     

        

        
    }
}