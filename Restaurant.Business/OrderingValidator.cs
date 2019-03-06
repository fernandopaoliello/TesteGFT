using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Dto.Meal;
using Restaurant.Dto.Dish;

namespace Restaurant.Business
{
    public class OrderingValidator
    {
        private List<int> listDishes;

        public OrderingValidator()
        {
        }

        public bool isInputValid(string input, out MealType meal)
        {
            bool isOK = false;
            meal = MealType.NOTAVAILABLE;

            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    string[] inputArray = input.Split(',').ToArray();

                    if (inputArray.Length >= 4)
                    {
                        meal = this.GetMealType(inputArray[0]);
                        if (meal != MealType.NOTAVAILABLE)
                        {
                            try
                            {
                                listDishes = new List<int>();
                                for (int i = 1; i < inputArray.Length; i++)
                                {
                                    int dishNumber = 0;
                                    bool aux = int.TryParse(inputArray[i].ToString().Trim(), out dishNumber);
                                    if (aux)
                                        listDishes.Add(dishNumber);
                                    else
                                        listDishes.Add(0);
                                }

                                isOK = true;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return isOK;
        }
        public List<int> GetListDishes()
        {
            return this.listDishes;
        }

        public DishType? GetToDishType(int dishType)
        {
            if (dishType > 0 && dishType < 5)
                return (DishType)dishType;
            else
                return null;
        }

        public MealType GetMealType(string input)
        {
            MealType mealtype = MealType.NOTAVAILABLE;
            try
            {
                mealtype = (MealType)Enum.Parse(typeof(MealType), input.ToUpper().Trim(), true);
                string x = "MealType Value: " + mealtype.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine("input: " + input + " " + ex.ToString());
            }

            return mealtype;
        }
    }
}
