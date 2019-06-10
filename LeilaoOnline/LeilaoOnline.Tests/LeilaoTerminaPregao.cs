using LeilaoOnline.Core;
using Xunit;

namespace LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {

        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperado, double[] ofertas)
        {
            //arrange
            var leilao = new Leilao("Van Gogh");
            var interessada1 = new Interessada("Maria", leilao);

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(interessada1, valor);
            }

            //act
            leilao.TerminaPregao();

            //assert
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLance()
        {
            //arrange
            var leilao = new Leilao("Van Gogh");

            //act
            leilao.TerminaPregao();

            //assert
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
