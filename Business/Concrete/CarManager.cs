﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;
        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }
        public void Add(Car entity)
        {
            if (entity.Description.Length > 2 && entity.DailyPrice > 0)
            {
                _CarDal.Add(entity);
            }
            else
            {
                if (entity.Description.Length < 2)
                {
                    Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır.");
                }
                else
                {
                    Console.WriteLine("Araba günlük fiyatı 0 'dan büyük olmalıdır.");
                }
            }
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }
        public List<Car> GetCarsByBrandId(int id)
        {
            return _CarDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _CarDal.GetAll(c => c.ColorId == id);
        }
    }
}
