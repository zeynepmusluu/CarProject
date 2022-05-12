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
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetByDailyPrice(1000,1050))
            {
                Console.WriteLine(car.Description);
            }
        }
    }

    
}
