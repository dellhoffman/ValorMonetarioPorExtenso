using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValorMonetario
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Entre com Valor > 0 e < 1000");
                string valor = Console.ReadLine();
                string valorPorExtenso = ValorMonetario.Converte(valor);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(valorPorExtenso);
                Console.WriteLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
