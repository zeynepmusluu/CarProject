using Business.Abstract;
using Business.Constants;
using Business.Constants.Messages;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Helpers.FileHelpers.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        string _defaultImageName = "images/default.png";

        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(int carId, IFormFile file)
        {
            var result = BusinessRules.Run(CheckIfTheImageLimitForThisCarHasBeenExceeded(carId));
            if (!result.Success) return result;

            var carImage = new CarImage
            {
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = _fileHelper.Add(file)
            };

            _carImageDal.Add(carImage);
            return new SuccessResult(CarImageMessages.Added);
        }

        public IResult Delete(int id)
        {
            var carImage = _carImageDal.Get(ci => ci.Id == id);
            _fileHelper.Delete(carImage.ImagePath);

            _carImageDal.Delete(carImage);
            return new SuccessResult(CarImageMessages.Deleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result, CarImageMessages.Listed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Count == 0) result.Add(new CarImage { ImagePath = _defaultImageName });
            return new SuccessDataResult<List<CarImage>>(result, CarImageMessages.Listed);
        }

        public IResult Update(int id, IFormFile file)
        {
            var carImage = _carImageDal.Get(ci => ci.Id == id);
            carImage.ImagePath = _fileHelper.Update(file, carImage.ImagePath);

            _carImageDal.Update(carImage);
            return new SuccessResult(CarImageMessages.Updated);
        }

        private IResult CheckIfTheImageLimitForThisCarHasBeenExceeded(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Count >= 5) return new ErrorResult(CarImageMessages.TheImageLimitForThisCarHasBeenExceeded);

            return new SuccessResult();
        }
    }
}
