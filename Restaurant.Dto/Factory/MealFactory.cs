using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Dto.Meal;

namespace Restaurant.Dto.Factory
{
    public class MealFactory
    {
        public static Meal.Meal CreateMeal(MealType type)
        {
            Meal.Meal meal = null;
            switch (type)
            {
                case MealType.MORNING:
                    meal = MorningFactory.Create();
                    break;
                case MealType.NIGHT:
                    meal = NightFactory.Create();
                    break;
            }
            return meal;
        }
    }
}
