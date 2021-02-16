using System.Collections.Generic;

namespace SystemTestingVariant9
{
    public static class ListFilterer
    {
        /// <summary>
        /// Фильтрует лист согласно условию из задания и возвращает его.
        /// </summary>
        public static List<int> Filter(List<int> numbers)
        {
            List<int> resultList = new List<int>();
            foreach (int number in numbers)
                if (!(NumberChecker.CheckIfPrime(number) && NumberChecker.CheckIfNextIsPrimePowerOfTwo(number)))
                    resultList.Add(number);

            return resultList;
        }
        
    }
}