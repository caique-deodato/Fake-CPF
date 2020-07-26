using System;

namespace FakeCPF {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Dados para verificação: ");

            Console.Write("CPF: ");
            long cpf1 = long.Parse(Console.ReadLine());

            Console.Write("Estado: ");
            string estado1 = Console.ReadLine();

            CPF pessoa1 = new CPF(cpf1, estado1);

            Console.WriteLine(pessoa1.CPFValido());


        }
    }

}
