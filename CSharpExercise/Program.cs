﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathFunctions;

namespace CSharpExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The value of 2pi squared is: {MathFunctionsClass.Square(2 * Math.PI):F3}");
            Console.WriteLine($"The value of pi cubed is: {MathFunctionsClass.Cube( Math.PI):F3}");

            bool loopContinue = true;
            while (loopContinue)
            {
                DisplayMenu();//Display selection menu
                // Use TryParse when reading the user input. This will avoid an 
                // Exception if the user types a letter for example.
                if (Int32.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1://Circumference of Circle
                            Console.Write("Enter radius： ");
                            if (double.TryParse(Console.ReadLine(), out double r) && r>0)//r need to be greater than 0
                            {
                                Console.WriteLine("You entered {0}", r);
                                Console.WriteLine("Circumference of Circle is {0:F3}", MathFunctionsClass.circumferenceOfCircle(r));
                                loopContinue = false;
                            }
                            else { Console.WriteLine("Please enter a valid number."); }
                            break;
                        case 2://Area of Circle
                            Console.Write("Enter radius： ");
                            if (double.TryParse(Console.ReadLine(), out double rr) && rr>0)//r need to be greater than 0
                            {
                                Console.WriteLine("You entered {0}", rr);
                                Console.WriteLine("Area of Circle is {0:F3}", MathFunctionsClass.areaOfCircle(rr));
                                loopContinue = false;
                            }
                            else { Console.WriteLine("Please enter a valid number."); }
                            break;
                        case 3://Volume of Hemisphere
                            Console.Write("Enter radius： ");
                            if (double.TryParse(Console.ReadLine(), out double rrr) && rrr>=0)//r need to be non-negative
                            {
                                Console.WriteLine("You entered {0}", rrr);
                                Console.WriteLine("Volume of Hemisphere is {0:F3}", MathFunctionsClass.volumeOfHemisphere(rrr)); ;
                                loopContinue = false;
                            }
                            else { Console.WriteLine("Please enter a valid number."); }
                            break;
                        case 4://Area of a triangle given length of three sides
                            Console.WriteLine("calculates the area of a triangle given integer lengths of the three sides.");
                            Console.Write("Enter side length 1: ");
                            if (!Int32.TryParse(Console.ReadLine(), out int a) || a < 0) break;//don't take negative value
                            Console.Write("Enter side length 2: ");
                            if (!Int32.TryParse(Console.ReadLine(), out int b) || b < 0) break;
                            Console.Write("Enter side length 3: ");
                            if (!Int32.TryParse(Console.ReadLine(), out int c) || c < 0) break;
                            Console.WriteLine("Area of Triangle is {0}", MathFunctionsClass.areaOfTriangle(a, b, c));
                            loopContinue = false;
                            break;
                        case 5://Solving a quadratic equation
                            Console.WriteLine("Solve ax^2+bx+c=0 given integer coeffients a, b, c.");
                            Console.Write("Enter a: ");
                            if (!Int32.TryParse(Console.ReadLine(), out int aa)) break; //validate input as integer
                            else if (aa == 0)
                            {
                                Console.WriteLine("You entered a=0. Equation will be solved as linear equation.");
                            };
                            Console.Write("Enter b: ");
                            if (!Int32.TryParse(Console.ReadLine(), out int bb)) break;
                            Console.Write("Enter c: ");
                            if (!Int32.TryParse(Console.ReadLine(), out int cc)) break;
                            if (aa !=0)   //solve the quadratic equation only if a!=0
                            {
                                var solution = MathFunctionsClass.quadraticEqn(aa, bb, cc);
                                Console.WriteLine("Solutions are {0},{1}", solution.Item1, solution.Item2);
                            }
                            else if (bb != 0) //Equation will be solved as linear equation and have one root if b!=0
                            {
                                double root = -1.0 * cc / bb;
                                Console.WriteLine($"Solution is {root}");
                                loopContinue = false;
                                break;
                            }
                            else if (cc != 0)
                            {
                                Console.WriteLine("Non-zero c=0. Solution does not exist.");
                            }
                            else
                            {
                                Console.WriteLine("a=b=c=0. x can be any number.");
                            }
                       
                            

                            loopContinue = false;
                            break;
                        // not really needed, if you remove the default
                        // then your loop will not exit and you can start again
                        default:
                            loopContinue = true;
                            break;
                    }
                    if (loopContinue)
                        Console.WriteLine("Please enter a valid input.");
                        Console.WriteLine();
                }
            }

            /*int userChoice = 0;
            do
            {
                userChoice = DisplayMenu();
                Console.WriteLine("You entered {0}", userChoice);
            } while (userChoice < 1 || userChoice > 5);*/


            /*string userInput;
            double radius;

            Console.Write("Enter radius：");
            userInput = Console.ReadLine();
            // Converts to double type 
            radius = Convert.ToDouble(userInput);
            Console.WriteLine("You entered {0}", radius);
            Console.WriteLine("Area of Circle is {0}", areaOfCircle(radius));
            Console.WriteLine("Circumference of Circle is {0:F4}", circumferenceOfCircle(radius));
            Console.WriteLine("Volume of Hemisphere is {0}", volumeOfHemisphere(radius));
            Console.WriteLine("Area of Triangle is {0}", areaOfTriangle(3,4,5));
            var solution = quadraticEqn(1, 3, 1);
            Console.WriteLine("Solutions are {0},{1}", solution.Item1, solution.Item2);*/
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Mathematical Formulas");
            Console.WriteLine("Make a selection 1-5 and hit enter");
            Console.WriteLine("1. Circumference of Circle");
            Console.WriteLine("2. Area of Circle");
            Console.WriteLine("3. Volume of a hemisphere");
            Console.WriteLine("4. Area of triangle given the length of the sides");
            Console.WriteLine("5. Solving a quadratic equation");
            //var result = int.Parse(Console.ReadLine());
            //return Convert.ToInt32(result);
        }

        /*public static double areaOfCircle(double r)
        {
            double Area = Math.PI * Math.Pow(r, 2);
            return Area;
        }

        public static double circumferenceOfCircle(double r)
        {
            double Cir = 2* Math.PI * r;
            return Cir;
        }

        public static double volumeOfHemisphere(double r)
        {
            double Vol = 4.0 / 3 * Math.PI * Math.Pow(r,3) / 2;//use 4.0 so that 4/3 is not 1
            return Vol;
        }

        public static double areaOfTriangle(int a, int b, int c)
        {
            double p = (a + b + c) / 2.0;
            double Area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return Area;
        }

        public static Tuple<double,double> quadraticEqn(int a, int b, int c)
        {
            double Delta = b * b - 4 * a * c;
            if (Delta >= 0)
            {
                double x1 = (-b + Math.Sqrt(Delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(Delta)) / (2 * a);
                var tuple = new Tuple<double, double>(x1, x2);
                return tuple;
            }
            else
            {
                Console.WriteLine("No Real Solution.");
                return new Tuple<double, double>(0.0, 0.0);
            }
        }*/
    }
}
