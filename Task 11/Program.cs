using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11
{
    class Program
    {
        /// <summary>
        /// Зашифровка текста
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns>Зашифрованная строка</returns>
        static string Coding(string str)
        {
            int row = 10, col = 0, iRow, jCol = 1;
            int num = str.Length - 1;                     // Позиция текущего символа
            char[,] mas = new char[row + 1, row + 1];     // Матрица для зашифровки
            do
            {
                // Верхняя горизонталь
                iRow = col;
                for (jCol = col; jCol <= row; jCol++)
                {
                    mas[iRow, jCol] = str[num];
                    num--;
                }
                // Правая вертикаль
                jCol = row;
                for (iRow = col + 1; iRow <= row; iRow++)
                {
                    mas[iRow, jCol] = str[num];
                    num--;
                }
                // Нижняя горизонталь
                iRow = row;
                for (jCol = row - 1; jCol >= col; jCol--)
                {
                    mas[iRow, jCol] = str[num];
                    num--;
                }
                // Левая вертикаль
                jCol = col;
                for (iRow = row - 1; iRow > col; iRow--)
                {
                    mas[iRow, jCol] = str[num];
                    num--;
                }
                row--; col++;
            }
            while (num > -1);

            // Соединение символов в строку
            str = "";
            for (iRow = 0; iRow < 11; iRow++)
                for (jCol = 0; jCol < 11; jCol++)
                    str += mas[iRow, jCol];
            return str;
        }

        /// <summary>
        /// Расшифровка текста
        /// </summary>
        /// <param name="str">Зашифрованная строка</param>
        /// <returns>Расшифрованная строка</returns>
        static string Decoding(string str)
        {
            int row = 10, col = 0;                      // Граничные строки и столбцы
            int num = 0;                                // Позиция текущего символа
            char[,] arr = new char[row + 1, row + 1];   // Матрица шифр

            // Перевод шифра в матрицу
            for (int i = 0; i <= row; i++)
                for (int j = 0; j <= row; j++)
                    arr[i, j] = str[num++];


            str = "";
            // Расшифровка текста по спирали в обратном порядке
            int iRow, jCol;
            do
            {
                // Горизонталь
                iRow = col;
                for (jCol = col; jCol <= row; jCol++)
                {
                    str = arr[iRow, jCol] + str;
                    num--;
                }
                // Вертикаль
                jCol = row;
                for (iRow = col + 1; iRow <= row; iRow++)
                {
                    str = arr[iRow, jCol] + str;
                    num--;
                }
                // Горизонталь
                iRow = row;
                for (jCol = row - 1; jCol >= col; jCol--)
                {
                    str = arr[iRow, jCol] + str;
                    num--;
                }
                // Вертикаль
                jCol = col;
                for (iRow = row - 1; iRow > col; iRow--)
                {
                    str = arr[iRow, jCol] + str;
                    num--;
                }
                row--; col++;
            }
            while (num > 0);
            return str;
        }


        static void Main(string[] args)
        {
            // Ввод строки
            Console.WriteLine("Введите строку");
            string str = "";
            do
            {
                str = Console.ReadLine();
                if (str.Length < 121) Console.WriteLine("Недостаточная длина текста. Повторите ввод.");

            } while (str.Length < 121);
            if (str.Length > 121) str = str.Substring(0, 121);

            // Меню
            string input = "";
            do
            {
                Console.WriteLine(@"Меню:
0. Выход
1. Зашифровать текст
2. Расшифровать текст");
                input = Console.ReadLine();
                switch (input)
                {
                    // Зашифровка
                    case ("1"):
                        str = Coding(str);
                        Console.WriteLine("Результат:");
                        Console.WriteLine(str);
                        break;
                    // Расшифровка
                    case ("2"):
                        str = Decoding(str);
                        Console.WriteLine("Результат:");
                        Console.WriteLine(str);
                        break;
                    case ("0"):
                        break;
                    default:
                        Console.WriteLine("Выбранного пункта не существует");
                        break;
                }
            }
            while (input != "0");
        }
    }
}
