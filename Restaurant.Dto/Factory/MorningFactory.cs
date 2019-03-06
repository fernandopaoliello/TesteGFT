using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Dto.Meal;
using Restaurant.Dto.Dish;
namespace Restaurant.Dto.Factory
{
    internal class MorningFactory
    {

        public static Morning Create()
        {
            Morning instance = new Morning();

            instance.Add(new Eggs());
            instance.Add(new Toast());

            Coffee obj = new Coffee();
            obj.EnableMultipleOrder();
            obj.Order(3);
            instance.Add(obj);

            return instance;
        }
    }
}
