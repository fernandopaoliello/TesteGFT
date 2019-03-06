using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Dto.Factory;
using Restaurant.Dto.Meal;
namespace Restaurant.UnitTest
{
    [TestClass]
    public class MealTest
    {
        [TestMethod]
        public void Meal_Night_Factory_OK()
        {
            Meal obj = MealFactory.CreateMeal(MealType.NIGHT);

            var meal = obj.Display(1);
            Console.WriteLine(meal);
            Assert.IsTrue(obj.Name == "Night");
        }

        [TestMethod]
        public void Meal_Morning_Factory_OK()
        {
            Meal obj = MealFactory.CreateMeal(MealType.MORNING);

            var meal = obj.Display(1);
            Console.WriteLine(meal);
            Assert.IsTrue(obj.Name == "Morning");
        }
    }
}
