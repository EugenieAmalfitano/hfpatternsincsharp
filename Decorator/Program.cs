using System;
using System.IO;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Beverage bev = new AfricanBlend
            {
                size = Beverage.Size.TALL
            };

            // Tall Plain African Blend
            ShowBeverage(bev);

            bev = new Cream(bev);
            // Grande African Blend with cream
            ShowBeverage(bev);

            bev = new HouseBlend
            {
                size = Beverage.Size.GRANDE
            };
            // Plain House Blend
            ShowBeverage(bev);

            // Grande House blend with 2x cream

            bev = new Cream(bev);
            bev = new Cream(bev);
            ShowBeverage(bev);

            // Venti African blend with 2 x cream and caramel
            bev = new AfricanBlend
            {
                size = Beverage.Size.VENTI
            };
            bev = new Cream(bev);
            bev = new Caramel(bev);
            ShowBeverage(bev);
            Console.ReadLine();          
        }

        static void ShowBeverage(Beverage bev)
        {
            Console.WriteLine(
                          String.Format("{0,-10} {1,-50} ${2,-6}",
                              bev.getSize(),
                              bev.GetDescription(),
                              bev.GetCost()));
        }
    }
}
