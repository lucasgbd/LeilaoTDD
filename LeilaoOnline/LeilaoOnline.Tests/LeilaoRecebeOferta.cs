using LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(3, new double[] { 800, 900, 1000 })]
        [InlineData(2, new double[] { 800, 900, 1000 })]
        [InlineData(4, new double[] { 800, 900, 1000 })]
        [InlineData(4, new double[] { 800, 900, 1000, 1400 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int valorEsperado, double[] ofertas)
        {
            //arrange
            var leilao = new Leilao("Van Gogh");
            var interessada1 = new Interessada("Maria", leilao);

            foreach (double valor in ofertas)
            {
                leilao.RecebeLance(interessada1, valor);
            }

            leilao.TerminaPregao();

            //act
            leilao.RecebeLance(interessada1, 1000);

            //assert
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, leilao.Lances.Count());
        }
    }
}
