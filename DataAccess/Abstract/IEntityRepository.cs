using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint (kısıt)
    //class= referance type
    //T ya Ientity olablir yada oradan implement edilen olablir.
     public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //filtreleri tek satırda yaptırıyo yani filtre yapmamızı sağlıyor. çok satanlara gçöre vb. gibi

        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter); 
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
