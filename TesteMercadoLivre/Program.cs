using System;
using System.Linq;

namespace TesteMercadoLivre
{
    static class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("\n1. Informe o tamanho dos números que quer obter:");
            int qMax = Convert.ToInt32(Console.ReadLine());
            GenerateNumbers(qMax);
        }

        static void GenerateNumbers(int maxDigits)
        {

            int correctResults = 0;

            var number = Enumerable.Range(maxDigits, 1);
            var min = Convert.ToInt32(number.Select(x => MaxIntWithXDigits(x).min).First());
            var max = Convert.ToInt32(number.Select(x => MaxIntWithXDigits(x).max).Last());


            Console.WriteLine($"\nOk! Número Mínimo: {min}" + 
                              $"\n    Número Máximo: {max}");

            Console.WriteLine("\n\n2. Agora informe um número máximo que cada dígito deve ter:");
            int dMax = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n\n2. Qual resultado é esperado?");
            int rEsp = Convert.ToInt32(Console.ReadLine());
                                              
            Console.WriteLine($"\n\n-----------R   E   S   U   L   T   A   D   O   S-----------\n");

            for (int i = min; i < max; i++)
            {
                if (ValidateActualNumber(i, maxDigits, dMax, rEsp))
                    correctResults++;
            }

            Console.WriteLine($"\n\n--> O número de resultados corretos foi de: {correctResults}");

            Console.ReadKey();
        }


        public static (int min, int max) MaxIntWithXDigits(this int x)
        {
            if (x <= 0 || x > 9)
                throw new ArgumentOutOfRangeException(nameof(x));

            int min = (int)Math.Pow(10, x - 1);

            return (min == 1 ? 0 : min, min * 10 - 1);
        }


        static bool ValidateActualNumber(int numToValidate, int maxDigits, int maxNumber, int expectedResult)
        {
            int cont = 0;
            int sum = 0;

            int[] numbers = new int[maxDigits];

            for(int i = 0; i < maxDigits; i++)
            {
                numbers[cont] = Convert.ToInt32(numToValidate.ToString().Substring(i, 1));
                cont++;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > maxNumber)
                    break;

                sum += numbers[i];
            }


            if (sum == expectedResult)
            {
                Console.WriteLine($"Ok o número {numToValidate} é válido para o resultado esperado {expectedResult}.");
                return true;
            }

            return false;


        }




    }
}
