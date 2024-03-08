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
        [InlineData(2, 20000, 390.689568, 302.7844152)]
        [InlineData(750, 20000, 28277558.14612243, 24035924.424204063)]
        public void CalcularSimples_Should_Ok(int pMeses, decimal pValor, Double pValorBruto, Double pValorLiquido)
        {
            var svc = new CalculoCdbService();
            svc.SetCache(new DataCache());
            var par = new CdbEntrada { Valor = pValor, Meses = pMeses };
            var ret = svc.CalcularSimples(par);
            Assert.Equal(pValorBruto, (Double)ret.RendimentoBruto);
            Assert.Equal(pValorLiquido, (Double)ret.RendimentoLiquido);
        }

        [Theory]
        [InlineData(2, 20000, 390.689568, 302.7844152)]
        [InlineData(750, 20000, 28277558.14612243, 24035924.424204063)]
        public void Calcular_Should_Ok(int pMeses, decimal pValor, Double pValorBruto, Double pValorLiquido)
        {
            var svc = new CalculoCdbService();
            svc.SetCache(new DataCache());
            var par = new CdbEntrada { Valor = pValor, Meses = pMeses };
            var ret = svc.Calcular(par);
            Assert.Equal(pValorBruto, (Double)ret.RendimentoBruto);
            Assert.Equal(pValorLiquido, (Double)ret.RendimentoLiquido);
        }

        [Theory]
        [InlineData(20, 0, CalculoCdbService.VALOR_INVALIDO)]
        [InlineData(0, 100, CalculoCdbService.MESES_INVALIDO)]
        [InlineData(1, 100, CalculoCdbService.MESES_INVALIDO)]
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