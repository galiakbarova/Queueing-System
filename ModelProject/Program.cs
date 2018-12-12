using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ModelProject
{
    public class Program
    {
        /// <summary>
        /// Интенсивность Пуассоновского процесса
        /// </summary>
        static double Lambda;

        /// <summary>
        /// Генерация случайного числа U[0, 1]
        /// </summary>
        public static double GenerateRandomU()
        {
            Random random = new Random();
            double U = random.NextDouble();
            return U;
        }

        /// <summary>
        /// Алгоритм генерации первых Т времен
        /// однородного Пуассоновского процесса
        /// </summary>
        public static List<double> GenerateHomoPoissonProcessTimes(double T)
        {
            double t = 0;
            double I = 0;
            List<double> S = new List<double>();

            while (true)
            {
                double U = GenerateRandomU();
                Console.WriteLine("Сгенерированное U - {0} ", Math.Round(U, 4));
                t -= 1 / Lambda * Math.Log(U, 2);
                if (t > T)
                    break;
                S.Add(t);
                Console.WriteLine("Момент времени t - {0} ", Math.Round(S.Last(), 4));
                I++;
                Console.WriteLine("Число событий, произошедших к моменту времени - {0} ", Math.Round(I, 4));
                Console.ReadKey();
            }

            return S;
        }

        /// <summary>
        /// Lambda(T)
        /// </summary>
        public static double LambdaT(double t, double T)
        {
            int roundT = (int)Math.Round(T);
            int roundt = (int)Math.Round(t);
            int section = roundT % 4;
            if (t < section)
                return 0.3;
            else if ((t >= section) && (t < 2 * section))
                return 0.5;
            else if ((t >= 2 * section) && (t < 3 * section))
                return 0.65;
            else return 0.68;
        }

        /// <summary>
        /// Алгоритм генерации первых Т времен
        /// неоднородного Пуассоновского процесса
        /// </summary>
        /// <param name="T">Конец интервала наблюдения</param>
        /// <returns>Список времен произошедших событий</returns>
        public static List<double> GenerateHeteroPoissonProcessTimes(double T)
        {
            double t = 0;
            double I = 0;
            List<double> S = new List<double>();

            while (true)
            {
                double U1 = GenerateRandomU();
                Console.WriteLine("Сгенерированное U1 - {0} ", Math.Round(U1, 4));
                t -= 1 / Lambda * Math.Log(U1, 2);
                if (t > T)
                    break;
                Thread.Sleep(500);
                double U2 = GenerateRandomU();
                Console.WriteLine("Сгенерированное U2 - {0} ", Math.Round(U2, 4));
                if (U2 <= LambdaT(t, T) / Lambda)
                {
                    S.Add(t);
                    Console.WriteLine("Момент времени t - {0} ", Math.Round(S.Last(), 4));
                    I++;
                    Console.WriteLine("Число событий, произошедших к моменту времени - {0} \n", Math.Round(I, 4));
                }
                Console.ReadKey();
            }

            return S;
        }


        static void Main(string[] args)
        {
            Lambda = 0.7;
            Console.WriteLine("Введите значение T:");
            double T = Convert.ToInt32(Console.ReadLine());
            List<double> S = GenerateHeteroPoissonProcessTimes(T);

            Console.ReadKey();
        }
    }
}
