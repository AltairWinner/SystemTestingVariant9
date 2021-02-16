﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SystemTestingVariant9
{
    public static class StringConverter
    {
        /// <summary>
        /// Метод конвертирует корректную строку из целых чисел в лист целых чисел
        /// </summary>
        /// <param name="str">Строка, которую необходимо преобразовать</param>
        /// <returns>Возвращает лист из целых чисел из переданной строки.</returns>
        public static List<int> StringToNumberArray(string str)
        {
            var substrings = NormalizeWhiteSpaceForLoop(str.Trim()).Split(' ');
            List<int> resultList = new List<int>();

            foreach (var substring in substrings)
                resultList.Add(Convert.ToInt32(substring));

            return resultList;
        }

        /// <summary>
        /// Метод конвертирует лист из целых чисел в строку чисел, разделенных пробелами.
        /// </summary>
        public static string NumberArrayToString(List<int> numbers)
        {
            string result = "";
            foreach (var number in numbers)
                result += number.ToString() + ' ';
            return result.TrimEnd(); //Не забываем убрать последний пробел перед возвратом
        }

        //https://stackoverflow.com/questions/6442421/c-sharp-fastest-way-to-remove-extra-white-spaces
        /// <summary>
        /// Метод убирает все лишние пробелы из строки
        /// </summary>
        public static string NormalizeWhiteSpaceForLoop(string input)
        {
            int len = input.Length,
                index = 0,
                i = 0;
            var src = input.ToCharArray();
            bool skip = false;
            char ch;
            for (; i < len; i++)
            {
                ch = src[i];
                switch (ch)
                {
                    case '\u0020':
                    case '\u00A0':
                    case '\u1680':
                    case '\u2000':
                    case '\u2001':
                    case '\u2002':
                    case '\u2003':
                    case '\u2004':
                    case '\u2005':
                    case '\u2006':
                    case '\u2007':
                    case '\u2008':
                    case '\u2009':
                    case '\u200A':
                    case '\u202F':
                    case '\u205F':
                    case '\u3000':
                    case '\u2028':
                    case '\u2029':
                    case '\u0009':
                    case '\u000A':
                    case '\u000B':
                    case '\u000C':
                    case '\u000D':
                    case '\u0085':
                        if (skip) continue;
                        src[index++] = ch;
                        skip = true;
                        continue;
                    default:
                        skip = false;
                        src[index++] = ch;
                        continue;
                }
            }

            return new string(src, 0, index);
        }
    }
}
