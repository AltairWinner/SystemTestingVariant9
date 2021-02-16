namespace SystemTestingVariant9
{
    public static class NumberChecker
    {
        public static bool CheckIfPrime(int number)
        {
            //Отрицательные числа не являются простыми
            if (number < 0)
                return false;

            //Проверяем, делится ли это число на что-то до себя. Если да хотя бы один раз - то число не простое.
            for (int i = 2; i < number; i++)
                if (number % i == 0)
                    return false;
            return true;
        }

        public static bool CheckIfNextIsPrimePowerOfTwo(int number)
        {
            //https://stackoverflow.com/questions/600293/how-to-check-if-a-number-is-a-power-of-2
            number++; //Берём следующее число

            int power = 0;
            bool flag = true;
            while (number != 1 && flag)
            {
                if (number % 2 == 0) //Если всё ещё делится на 2 без остатка - продолжаем
                {
                    number /= 2;
                    power++;
                }
                else flag = false; //Иначе это число не является степенью 2
            }

            //Если число оказалось степенью 2 - проверяем, является ли степень простым числом
            if (flag)
                return CheckIfPrime(power);
            else //Иначе - нет
                return false;
        }
    }
}