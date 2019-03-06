﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Dto.Dish
{
    public class ErrorDish : Dish
    {
        public ErrorDish()
        {
            this._name = "Error";
            this._dishType = DishType.ERROR;
        }

        public override void Add(Dish c)
        {
            Console.WriteLine("Cannot add to a ErrorDish");
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
