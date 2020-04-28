using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexD_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Complex> M = new List<Complex>();
            Complex a = new Complex(3, 2);
            Complex b = new Complex(2, 1);
            Complex c;

            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);

            c = a + b;
            Console.WriteLine("a + b = {0}", c);

            c = a - b;
            Console.WriteLine("a - b = {0}", c);

            c = a * b;
            Console.WriteLine("a * b = {0}", c);

            Console.Write("Give the power value: ");
            int power = int.Parse(Console.ReadLine());
            c = a ^ power;
            Console.WriteLine("a ^ {0} = {1}", power, c);

            a.Trigonometric_PowerUp(power);
            a.Trigonometric_Form();

            for (int i = 1; i <= 10; i++)
            {
                Random rand = new Random();
                M.Add(new Complex(rand.Next(-10, 11), rand.Next(-10, 11)));
            }

            Console.WriteLine("The minimum distance between the complex number " + a + " and the rest of complex numbers is " + a.Min_Dist(M));

            Console.ReadKey();
        }
    }

    internal class Complex
    {
        private int real;
        private int imaginary;

        public Complex() : this(0)
        {
        }

        public Complex(int real_part)
        {
            real = real_part;
            imaginary = 0;
        }

        public Complex(int real_part, int imaginary_part)
        {
            real = real_part;
            imaginary = imaginary_part;
        }

        public static Complex operator +(Complex c) => c;
        public static Complex operator -(Complex c) => new Complex(-c.real, -c.imaginary);

        public static Complex operator +(Complex a, Complex b)
           => new Complex(a.real + b.real, a.imaginary + b.imaginary);

        public static Complex operator -(Complex a, Complex b) => a + (-b);

        public static Complex operator *(Complex a, Complex b)
            => new Complex(a.real * b.real - a.imaginary * b.imaginary, a.real * b.imaginary + a.imaginary * b.real);

        public static Complex operator ^(Complex a, int b)
        {
            Complex x = a;

            for (int i = 2; i <= b; i++)
                x *= a;

            return x;
        }

        public void Trigonometric_PowerUp(int b)
        {
            double r = Math.Sqrt(real * real + imaginary * imaginary);
            double teta = Math.Atan(imaginary / real);

            double aux = r;

            for (int i = 2; i <= b; i++)
                r *= aux;

            Console.WriteLine("The trigonometric form of the complex number powered up is {0} * ({1} + i * {2})", r, Math.Cos(b * teta), Math.Sin(b * teta));
        }

        public double Min_Dist(List<Complex> C)
        {
            double answer = Math.Sqrt((C[0].real - real) * (C[0].real - real) + (C[0].imaginary - imaginary) * (C[0].imaginary - imaginary));

            for (int i = 1; i < C.Count; i++)
                if (Math.Sqrt((C[i].real - real) * (C[i].real - real) + (C[i].imaginary - imaginary) * (C[i].imaginary - imaginary)) < answer)
                    answer = Math.Sqrt((C[i].real - real) * (C[i].real - real) + (C[i].imaginary - imaginary) * (C[i].imaginary - imaginary));

            return answer;
        }

        public void Trigonometric_Form()
        {
            double r = Math.Sqrt(real * real + imaginary * imaginary);
            double teta = Math.Atan(imaginary / real);

            Console.WriteLine("The trigonometric form of the complex number is {0} * ({1} + i * {2})", r, Math.Cos(teta), Math.Sin(teta));
        }

        public override string ToString() => $"{real} + {imaginary} * i";
    }
}
