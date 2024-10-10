using System;
using ConsoleApp.Entities;

class Program
{
    static void Main()
    {
        Console.Write("Digite o CPF: ");
        string cpf = Console.ReadLine();

        if (ValidadorCPF.Validar(cpf))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CPF válido.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("CPF inválido.");
        }
    }
}
