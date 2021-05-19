using System;

namespace LuckyTicket
{
    class Program
    {
        //Дан номер трамвайного билета, в котором суммы первых трёх цифр и последних трёх цифр отличаются на 1
        //(но не сказано, в какую сторону). Правда ли, что предыдущий или следующий билет счастливый?
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int a = rnd.Next(0, 9);
            int b = rnd.Next(0, 9);
            int c = rnd.Next(0, 9);
            int i = 0;
            int j = 0;
            int k = 0;
            int sum1 = a + b + c;
            bool f = true;
            while (f)
            {
                i = rnd.Next(0, 9);
                j = rnd.Next(0, 9);
                k = rnd.Next(0, 9);
                int sum2 = i + j + k;
                if ((sum2 == sum1 - 1) || (sum2 == sum1 + 1))
                    f = false;
            }
            // предыдущий билет
            int l = i * 100 + j * 10 + k;
            int pl = l - 1;
            Console.WriteLine("ticket numbers: {0} {1} {2} - {3} {4} {5} ", a, b, c, i, j, k);
            if (!CheckLucky(sum1, pl))
            {
                int nl = l + 1;
                if (CheckLucky(sum1, nl))
                    Console.WriteLine("Lucky ticket is next"); 
                else
                    Console.WriteLine("There is no lucky");
            }
            else
                Console.WriteLine("Lucky ticket is prev");
        }

        static void DisAssembleInt(int p, out int i, out int j, out int k)
        {
            i = p % 10;
            p /= 10;
            j = p % 10;
            p /= 10;
            k = p % 10;
        }

        public static bool CheckLucky(int sum, int p)
        {
            DisAssembleInt(p, out int i, out int j, out int k);
            return sum == (i + j + k);
        }
    }
}
