using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adeline
{
    class Program
    {

        static bool escalon(double w1, double w2, double b, double l1, double l2)
        {
            double res = (l1 * w1) + (l2 * w2) + ((-1) * b);
            if (l1 == 1 && l2 == 1)
                if (res > 0.0000001)
                    return true;
                else
                    return false;
            else if (l1 == 0 && l2 == 1)
                if (res <= 0.0000001)
                    return true;
                else
                    return false;
            else if (l1 == 1 && l2 == 0)
                if (res <= 0.0000001)
                    return true;
                else
                    return false;
            else
                if (res <= 0.0000001)
                return true;
            else
                return false;
        }

        static double Error(double w, double Error, double l, double n)
        {
            double wn = w + (Error * l * n);

            return wn;
        }

        static void Main(string[] args)
        {
            long contador = 1;
            double w1, w2, b;
            bool done = false;
            Random rnd = new Random();
            w1 = rnd.Next(1, 1000);
            w2 = rnd.Next(1, 1000);
            b = 1;
            while (!done)
            {
                check1:
                if (!escalon(w1, w2, b, 0, 0))
                {
                    double res = (0 * w1) + (0 * w2) + ((-1) * b);
                    double er = 0 - res;
                    // incorporar un ajuste para el bias
                    b = b + (-1 * 0.3);
                    w1 = Error(w1, er, 0, 0.3);
                    w2 = Error(w2, er, 0, 0.3);
                    contador++;
                    goto check1;
                }
                check2:
                if (!escalon(w1, w2, b, 0, 1))
                {
                    double res = (0 * w1) + (1 * w2) + ((-1) * b);
                    double er = 0 - res;
                    b = b + (-1 * 0.3);
                    w1 = Error(w1, er, 0, 0.3);
                    w2 = Error(w2, er, 1, 0.3);
                    contador++;
                    goto check2;
                }
                check3:
                if (!escalon(w1, w2, b, 1, 0))
                {
                    double res = (1 * w1) + (0 * w2) + ((-1) * b);
                    double er = 0 - res;
                    b = b + (-1 * 0.3);
                    w1 = Error(w1, er, 1, 0.3);
                    w2 = Error(w2, er, 0, 0.3);
                    contador++;
                    goto check3;
                }
                check4:
                if (!escalon(w1, w2, b, 1, 1))
                {
                    double res = (1 * w1) + (1 * w2) + ((-1) * b);
                    double er = 1 - res;
                    b = b + (1 * 0.3);
                    w1 = Error(w1, er, 1, 0.3);
                    w2 = Error(w2, er, 1, 0.3);
                    contador++;
                    goto check4;
                }
                done = true;
            }
            Console.WriteLine("El numero de iteraciones fue: " + contador.ToString());
            Console.WriteLine("Los valores Aleatorios son:");
            Console.WriteLine("  W1: " + w1.ToString());
            Console.WriteLine("  W2: " + w2.ToString());
            Console.WriteLine("   B: " + b.ToString());
            Console.ReadLine();
        }
    }
}
