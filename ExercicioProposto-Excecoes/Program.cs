using System;
using System.Globalization;
using ExercicioProposto_Excecoes.Entities;
using ExercicioProposto_Excecoes.Entities.Exceptions;

namespace ExercicioProposto_Excecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            int opt = 1;
            switch (opt)
            {
                case 1:
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("Enter account data".ToUpper());
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine();
                        Console.Write("Number: ");
                        int inputNum = int.Parse(Console.ReadLine());

                        Console.Write("Holder: ");
                        string inputName = Console.ReadLine();

                        Console.Write("Initial balance: ");
                        double inputBalance = double.Parse(Console.ReadLine());

                        Console.Write("Withdraw limit: ");
                        double inputLimit = double.Parse(Console.ReadLine());

                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine();
                        Console.Write("Enter amount for withdraw: ".ToUpper());
                        double inputWithdraw = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        Account acc = new Account(inputName, inputNum, inputBalance, inputLimit);
                        acc.Withdraw(inputWithdraw);

                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine($"New balance for {acc.Holder}'s account:" +
                            $" ${acc.Balance.ToString("F2", CultureInfo.InvariantCulture)}");
                    }
                    catch (DomainException e)
                    {
                        Console.WriteLine();
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("Withdraw error: " + e.Message);
                        Console.WriteLine();
                        Console.WriteLine("The program will restart in a few seconds.");
                        Console.WriteLine("----------------------------------------");
                        System.Threading.Thread.Sleep(3000);
                        goto case 1;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine();
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("Format error: " + e.Message);
                        Console.WriteLine();
                        Console.WriteLine("The program will restart in a few seconds.");
                        Console.WriteLine("----------------------------------------");
                        System.Threading.Thread.Sleep(3000);
                        goto case 1;
                    }
                    break;
            }
        }
    }
}


