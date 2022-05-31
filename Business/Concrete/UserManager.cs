﻿using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidaton;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(UserMessages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(UserMessages.UserDeleted);
        }
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(UserMessages.UserUpdated);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),UserMessages.UsersListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.UserId==id),UserMessages.UserListed);
        }

       
    }
}
