﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Dto.Dish
{
    public class Steak : Dish
    {
        public Steak()
        {
            this._name = "Steak";
            this._dishType = DishType.ENTREE;
        }
        public override void Add(Dish c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Dish c)
        {
            Console.WriteLine("Cannot add to a " + this.Name);
        }

        public override string Display(int depth)
        {
            return this.Name;
        }
    }
}
