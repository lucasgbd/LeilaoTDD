using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeilaoOnline.Core;

namespace LeilaoOnline.ConsoleApp
{
    class Program
    {
        private static void Verifica(double esperado, double obtido)
        {
            var cor = Console.ForegroundColor;

            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teste passou.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Teste falhou. Esperado: {esperado} - Obtido: {obtido}");
            }
            Console.ForegroundColor = cor;
        }

        private static void LeilaoComApenasUmLance()
        {
            //arrange
            var leilao = new Leilao("Van Gogh");
            var interessada1 = new Interessada("Maria", leilao);
            
            leilao.RecebeLance(interessada1, 1800);
            
            //act
            leilao.TerminaPregao();

            //assert
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);

        }

        private static void LeilaoComVariosLances()
        {
            //arrange
            var leilao = new Leilao("Van Gogh");
            var interessada1 = new Interessada("Maria", leilao);
            var interessada2 = new Interessada("Lucas", leilao);


            leilao.RecebeLance(interessada1, 800);
            leilao.RecebeLance(interessada2, 900);
            leilao.RecebeLance(interessada1, 1000);
            leilao.RecebeLance(interessada2, 990);

            //act
            leilao.TerminaPregao();

            //assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);
        }

        static void Main()
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();

            Console.ReadLine();
        }
    }
}
