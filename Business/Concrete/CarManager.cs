using Business.Abstract;
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
        ICarDal _CarDal;
        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }
        public IResult Add(Car entity)
        {
            if (entity.CarName.Length > 2 && entity.DailyPrice > 0)
            {
                _CarDal.Add(entity);
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

            _CarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        public IResult Update(Car car)
        {
            _CarDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>( _CarDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>( _CarDal.GetAll(c=>c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>( _CarDal.GetAll(clr => clr.ColorId == colorId));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>( _CarDal.GetAll(c=>c.DailyPrice >= min && c.DailyPrice <= max ));
        }

        public IDataResult <List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_CarDal.GetCarDetails());
        }
        
    }
}
