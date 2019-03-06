using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Dto.Meal;
using Restaurant.Dto.Factory;
using Restaurant.Dto.Dish;

namespace Restaurant.Business
{
    public class Ordering
    {
        private Meal _meal;

        public Ordering()
        {
        }
 

        public void CreateMeal(string input)
        {
            if (this._meal == null)
            {
                MealType meal = MealType.NOTAVAILABLE;
                var validator = new OrderingValidator();
                if (validator.isInputValid(input, out meal))
                {
                    if (meal != MealType.NOTAVAILABLE)
                    {
                        this._meal = MealFactory.CreateMeal(meal);

                        var listDishes = validator.GetListDishes().OrderBy(x => x).GroupBy(x => x);
                        bool hasError = false;

                        foreach (var item in listDishes)
                        {
                            DishType? currentDishType = validator.GetToDishType(item.Key);
                            int dishRepetition = item.Count();

                            if (currentDishType != null)
                            {
                                var dish = this._meal.Dishes.Where(x => x.DishType == currentDishType).FirstOrDefault();
                                if (dishRepetition > 1)
                                {
                                    if (dish.HasMultipleOrder())
                                    {
                                        dish.HasOrdered = true;
                                        dish.Order(dishRepetition);
                                    }
                                    else
                                        dish = new ErrorDish();
                                }
                                else
                                {
                                    if (dish != null)
                                    {
                                        dish.HasOrdered = true;
                                        dish.Order(1);
                                    }

                                    if (currentDishType == DishType.DESERT && meal == MealType.MORNING)
                                    {
                                        this._meal.Add(new ErrorDish());
                                    }
                                }
                            }
                            else
                            {
                                if (!hasError)
                                    this._meal.Add(new ErrorDish());
                            }
                        }

                        ValidOrder();
                    }
                    else
                    {
                        this._meal = new Meal("Error");
                        this._meal.Add(new ErrorDish());
                    }
                }
            }
        }


        private void ValidOrder()
        {
            for (int i = 0; i < this._meal.Dishes.Count; i++)
            {
                if (!this._meal.Dishes[i].HasOrdered)
                {
                    this._meal.Dishes[i] = new ErrorDish();
                }
            }
        }
               
        public string DisplayMeal()
        {
            string display = "";
            if (this._meal != null)
            {
                display = this._meal.Display(0).ToLower().Trim();
            }
            else
            {
                display = new ErrorDish().Display(0).ToLower().Trim();
            }
            return display;
        }
    }
}
