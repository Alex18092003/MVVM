using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    static class Model
    {
        public static List<string> dataList = new List<string> { "Сложение", "Вычитание", "Умножение", "Деление" };
        public static List<string> dataListOperation = new List<string> { "+", "-", "*", "/" };
        
        public static string OneNumber;
        public static string TwoNumber;
        public static string textResult;
    }
}
