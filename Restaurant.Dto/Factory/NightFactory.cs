using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Dto.Meal;
using Restaurant.Dto.Dish;
namespace Restaurant.Dto.Factory
{
    internal class NightFactory
    {

        public static Night Create()
        {
            Night instance = new Night();
            instance.Add(new Steak());
            Potato obj = new Potato();
            obj.EnableMultipleOrder();
            instance.Add(obj);
            instance.Add(new Wine());

            instance.Add(new Cake());

            return instance;
        }
    }
}
