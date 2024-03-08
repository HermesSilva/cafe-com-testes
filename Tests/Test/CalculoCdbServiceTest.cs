using System.Diagnostics.CodeAnalysis;

using Models;

using Services.Cache;
using Services.Services;

using Toolkit;

namespace Test
{

    [ExcludeFromCodeCoverage]
    public class CalculoCdbServiceTest
    {
        [Theory]
        [InlineData(1, 20000, 194.40, 150.66)]
        [InlineData(2, 20000, 390.689568, 302.7844152)]
        public void CalcularSimples_Should_Ok(int pMeses, decimal pValor, decimal pValorBruto, decimal pValorLiquido)
        {
            var svc = new CalculoCdbService();
            svc.SetCache(new DataCache());
            var par = new CdbEntrada { Valor = pValor, Meses = pMeses };
            var ret = svc.CalcularSimples(par);
            Assert.Equal(pValorBruto, ret.RendimentoBruto);
            Assert.Equal(pValorLiquido, ret.RendimentoLiquido);
        }

        [Theory]
        [InlineData(1, 20000, 194.40, 150.66)]
        [InlineData(2, 20000, 390.689568, 302.7844152)]
        public void Calcular_Should_Ok(int pMeses, decimal pValor, decimal pValorBruto, decimal pValorLiquido)
        {
            var svc = new CalculoCdbService();
            svc.SetCache(new DataCache());
            var par = new CdbEntrada { Valor = pValor, Meses = pMeses };
            var ret = svc.Calcular(par);
            Assert.Equal(pValorBruto, ret.RendimentoBruto);
            Assert.Equal(pValorLiquido, ret.RendimentoLiquido);
        }

        [Theory]
        [InlineData(20, 0, CalculoCdbService.VALOR_INVALIDO)]
        [InlineData(0, 100, CalculoCdbService.MESES_INVALIDO)]
        public void Calcular_Should_ParametrosInvalido(int pMeses, decimal pValor, string pMsg)
        {
            var svc = new CalculoCdbService();
            var par = new CdbEntrada { Valor = pValor, Meses = pMeses };
            var ex = Assert.Throws<MyException>(() => svc.Calcular(par));
            Assert.Equal(pMsg, ex.Message);
        }

        [Fact]
        public void Calcular_Should_ParametrosNull()
        {
            var svc = new CalculoCdbService();
            var ex = Assert.Throws<MyException>(() => svc.Calcular(null));
            Assert.Equal(CalculoCdbService.PARAM_NULL, ex.Message);
        }
    }
}