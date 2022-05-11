using Business.Concrete;
using DataAccess.Abstract;
using System;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + "/" + car.BrandId + "/"+ car.ColorId +"/" + car.DailyPrice + "/" + car.Description);
            }
        }
    }

    
}
