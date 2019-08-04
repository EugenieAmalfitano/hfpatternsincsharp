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
                size = Beverage.Size.GRANDE
            };

            // Plain African Blend
            ShowBeverage(bev);

            bev = new Cream(bev);
            // African Blend with cream
            ShowBeverage(bev);

            bev = new HouseBlend
            {
                size = Beverage.Size.TALL
            };
            // Plain House Blend
            ShowBeverage(bev);

            // House blend with 2x cream

            bev = new Cream(bev);
            bev = new Cream(bev);
            ShowBeverage(bev);

            // African blend with 2 x cream and caramel
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
