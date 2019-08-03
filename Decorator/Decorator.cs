﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public abstract class Beverage
    {
        public string description = "Unknown Beverage";

        public virtual string GetDescription()
        {
            return this.description;
        }

        public abstract double GetCost();
    }

    public class AfricanBlend : Beverage
    {
        public AfricanBlend()
        {
            this.description = "African Blend";
        }

        public override double GetCost()
        {
            return 1.99;
        }
    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            this.description = "House Blend";
        }

        public override double GetCost()
        {
            return 0.89;
        }
    }

    public abstract class CondimentDecorator : Beverage
    {
    }

    public class Cream : CondimentDecorator
    {
        Beverage beverage;

        public Cream(Beverage newBeverage)
        {
            this.beverage = newBeverage;
        }

        public override string GetDescription()
        {
            return this.beverage.GetDescription() + " + Cream";
        }

        public override double GetCost()
        {
            return 0.20 + this.beverage.GetCost();
        }
    }

    public class Caramel : CondimentDecorator
    {
        Beverage beverage;

        public Caramel(Beverage newBeverage)
        {
            this.beverage = newBeverage;
        }

        public override string GetDescription()
        {
            return this.beverage.GetDescription() + " + Caramel";
        }

        public override double GetCost()
        {
            return 0.75 + this.beverage.GetCost();
        }
    }
}
