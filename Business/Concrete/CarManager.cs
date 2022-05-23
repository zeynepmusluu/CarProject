﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult Add(Car entity)
        {
            if (entity.CarName.Length > 2 && entity.DailyPrice > 0)
            {
                _carDal.Add(entity);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                if (entity.CarName.Length < 2)
                {
                    return new ErrorResult(Messages.CarNameInvalid);
                }
                else
                {
                    return new ErrorResult(Messages.CarDailyPriceInvalid);
                }
            }
        }
        public IResult Delete(Car car)
        {

            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId == Id),Messages.CarsByBrandId);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(clr => clr.ColorId == Id),Messages.CarsByColorId);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.DailyPrice >= min && c.DailyPrice <= max ));
        }

        public IDataResult <List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarsDetailsListed);
        }

        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == Id),Messages.CarsListed);
        }
    }
}
