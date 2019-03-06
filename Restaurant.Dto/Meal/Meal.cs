using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Restaurant.Dto.Meal
{
    public class Meal : Dish.Dish
    {
        private List<Dish.Dish> children = new List<Dish.Dish>();

        public Meal(string name)
            : base(name)
        {
        }

        public List<Dish.Dish> Dishes
        {
            get { return this.children; }
        }

        public override void Add(Dish.Dish component)
        {
            children.Add(component);
        }

        public override void Remove(Dish.Dish component)
        {
            children.Remove(component);
        }
        
        public override string Display(int depth)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (Dish.Dish component in children)
            {
                sb.Append(" " + component.Display(1) + ",");
                if (component.DishType == Dish.DishType.ERROR)
                {
                    break;
                }
            }
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }
    }
}
