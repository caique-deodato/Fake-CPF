using System;

namespace FakeCPF {
    class Program {
        static void Main(string[] args) {


            CPF cpf = new CPF(Console.ReadLine());

            if (cpf.Valido())
            {
                Console.WriteLine("CPF Válido!!!!");
            }
            else
            {
                Console.WriteLine("CPF Inválido!");
            }
        }
    }

}
