﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public abstract class Beverage
    {
        public enum Size { TALL, GRANDE, VENTI};
        public Size size;

        public string description = "Unknown Beverage";

        public virtual string GetDescription()
        {
            return description;
        }

        public void setSize(Size size)
        {
            this.size = size;
        }

        public virtual Size getSize()
        {
            return size;
        }
        
        public abstract double GetCost();
    }

    public class AfricanBlend : Beverage
    {
        public AfricanBlend()
        {
            description = "African Blend";
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
            description = "House Blend";
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
        readonly Beverage beverage;

        public Cream(Beverage newBeverage)
        {
            beverage = newBeverage;
        }

        public override Size getSize()
        {
            return beverage.getSize();
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + " + Cream";
        }

        public override double GetCost()
        {
            double[] sizeCost = new double[] { .10, .15, .20};
            int i = (int)beverage.getSize();
            return sizeCost[i] + beverage.GetCost();
        }
    }

    public class Caramel : CondimentDecorator
    {
        readonly Beverage beverage;

        public Caramel(Beverage newBeverage)
        {
            beverage = newBeverage;
        }

        public override Size getSize()
        {
            return beverage.getSize();
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + " + Caramel";
        }

        public override double GetCost()
        {
            double[] sizeCost = new double[] { .60, .75, .90 };
            int i = (int)beverage.getSize();
            return sizeCost[i] + beverage.GetCost();
        }
    }
}
