using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //params verdiğim zaman Run metodu içerisine istediğim kadar parametre olarak IResult verebiliyorum.Gönderdiğimiz bütün parametreleri array haline getirip logics'e atanıyor.
        {
            foreach (var logic in logics) // iş kuralları
            {
                if (!logic.Success) //eğer kural çalışmazsaa
                {
                    return logic; //mevcut hatayı döndür
                }
            }
            return new SuccessResult(); //kurallar da sroun yoksa null döndür
        }
    }
}
