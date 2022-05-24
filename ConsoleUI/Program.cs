using Business.Concrete;
using DataAccess.Abstract;
using System;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success==true)
            {
                foreach (var car in result.Data )
                {
                    Console.WriteLine(car.BrandName + " - " + car.CarName + " - " + car.ColorName + " - " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           

        }
    }

    
}
