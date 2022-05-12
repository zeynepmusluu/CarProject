using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _ColorDal;
        public ColorManager(IColorDal carDal)
        {
            _ColorDal = carDal;
        }
        public List<Color> GetAll()
        {
            return _ColorDal.GetAll();
        }

  
    }
}
