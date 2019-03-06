using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Business;
using Restaurant.Dto.Meal;

namespace Restaurant.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";

            Console.WriteLine("To exit, digit e.");
            Console.Write("Please, input your order: ");

            while ((input = Console.ReadLine().ToLower()) != "e")
            {
                Ordering ordering = new Ordering();
                ordering.CreateMeal(input);
                Console.WriteLine(ordering.DisplayMeal());

                Console.Write("Please, input your order: ");
            }
        }
    }
}
