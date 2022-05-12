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
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId + "/"+ car.ColorId +"/" + car.ModelYear + "/" + car.DailyPrice + "/" + car.Description);
            }
        }
    }

    
}
