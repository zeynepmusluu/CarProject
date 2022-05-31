using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants.Messages
{
    public class CarImageMessages
    {
        public static string Added = "Araba görseli eklendi.";
        public static string Deleted = "Araba görseli silindi.";
        public static string Updated = "Araba markası güncellendi.";
        public static string Listed = "Araba görselleri listelendi.";
        public static string TheImageLimitForThisCarHasBeenExceeded = "Bu araba için daha fazla resim eklenemez.";
        public static string UnsupportedFileType = "Desteklenmeyen dosya türü";
    }
}
