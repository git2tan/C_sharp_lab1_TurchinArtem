using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_lab1_TurchinArtem
{
    class Program
    {
        public enum assignment : int { arr=1, strings, regExpression, exit };
       

        static void Main(string[] args)
        {
            String[] AssigmentString = {"Массивы","Строки", "Рег.выражения" };
            Console.WriteLine("Привет! Это моя первая лаба на языке C#... Мой вариант №7");
            //int input;
            assignment input;
            //input = (assignment)int.Parse(Console.ReadLine());
            //Console.WriteLine("Вы ввели {0} то есть {1}",(int)input, Enum.GetName(typeof(assignment),input));
            //input = int.Parse(Console.ReadLine());
            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("Введи номер задания 1(Массивы), 2(строки), 3(рег. выражения) или 4 для выхода.");
                input = (assignment)int.Parse(Console.ReadLine());
                switch (input)
                {

                    case assignment.arr:
                        WorkWithArray(); break;
                    case assignment.strings:
                        WorkWithString(); break;
                    case assignment.regExpression:
                        WorkWithRegExpression(); break;
                    case assignment.exit:
                        isExit = true; break;
                    default:
                        Console.WriteLine("вы ввели нето что вас просили!\n"); break;
                }
            }
        }

        public static void WorkWithArray()
        {
            Console.WriteLine("Вы выбрали работу с массивами...\nПриступим!");
            Console.WriteLine("Введите размер массива одной цифрой (массив квадратный)");
            int size;
            size = int.Parse(Console.ReadLine());
            Console.WriteLine("Приступаю к заполнению массива...");
            double[,] tmpArray = new double[size, size];
            Random realRnd = new Random();
            //foreach(double one in tmpArray)
            //{

            //}
            Console.WriteLine("массив до редактирования:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    tmpArray[i, j] = realRnd.NextDouble();
                    Console.Write("[{0:f2}]   ",tmpArray[i,j]);
                }
                Console.Write("\n\n");
            }
            Console.WriteLine("массив после редактирования:");
            
            for(int iR=0,jC=size-1;iR<size-1;iR++,jC-- )
            {
                for(int iC=0,jR=size-1;iC<size-1-iR;iC++,jR--)
                {
                    double c = tmpArray[iR, iC];
                    tmpArray[iR, iC] = tmpArray[jR, jC];
                    tmpArray[jR, jC] = c;
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //tmpArray[i, j] = realRnd.NextDouble();
                    Console.Write("[{0:f2}]   ", tmpArray[i, j]);
                }
                Console.Write("\n\n");
            }
        }
        public static void WorkWithString()
        {
            Console.WriteLine("Вы выбрали работу со строками...\nПриступим!");
            Console.WriteLine("Введите строку?");
            string tmpStr = Console.ReadLine();
            string resultStr="";
            string[] words;
            //words = tmpStr.Split(' ', '!', ',', '.', '?');
            words = tmpStr.Split(' ');
            foreach (string oneWord in words)
            {
                if(oneWord.Length>0)
                {
                    if (resultStr.Length == 0)
                        resultStr += oneWord;
                    else
                        resultStr = resultStr + " " + oneWord;
                }
            }
            Console.WriteLine("Результат:");
            Console.WriteLine(resultStr);
        }

        public static void WorkWithRegExpression()
        {
            Console.WriteLine("Вы выбрали работу с регулярными выражениями");
            Console.WriteLine("Использовать строку \"по-умолчанию\"(0) или ввести самостоятельно(1)?");
            int input = int.Parse(Console.ReadLine());
            string tmpText="";
            if (input == 0)
            {
                tmpText = "Информатика! Это информатика. Информатика это наука!. Наука об информатике! Информатика и информатика. Информатика - это информатика.";
                Console.WriteLine(tmpText);
            }
            else if (input == 1)
                tmpText = Console.ReadLine();
            else
                Console.WriteLine("Вы ввели неправильный номер! Try harder!!!");

            if (tmpText.Length > 0)
            {

                Regex r = new Regex(@"^(Информатика)([.])*([.?!])");

                var simpleStr = r.Matches(tmpText);
                int count = simpleStr.Count;
                int count1 = 0;
                Console.WriteLine("out:");
                foreach (var s in simpleStr)
                {
                    count1++;
                    Console.WriteLine(s);
                }
                Console.WriteLine("Количество найденных совпадений = {0} или {1}",count,count1);
            }
        }
    }
}
