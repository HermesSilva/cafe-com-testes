using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Models;
using Models.Interfaces;

using NSubstitute;

using Services.Interfaces;
using Services.Services;

using WebAPI.Controllers;

namespace Test
{
    [ExcludeFromCodeCoverage]
    public class CdbControllerTest
    {
        public CdbControllerTest()
        {
            _Logger = Substitute.For<ILogger<CdbController>>();
            _Cache = Substitute.For<IDataCache>();
            _Service = Substitute.For<ICalculoCdbService>();
        }

        private readonly ILogger<CdbController> _Logger;
        private readonly IDataCache _Cache;
        private readonly ICalculoCdbService _Service;

        [Theory]
        [InlineData(2, 20000, 390.689568, 302.7844152)]
        [InlineData(750, 20000, 28277558.14612243, 24035924.424204063)]
        public void Calcular_Shoud_Ok(int pMeses, decimal pValor, decimal pValorBruto, decimal pValorLiquido)
        {
            var target = CreateTarget();
            var req = new CdbEntrada { Meses = pMeses, Valor = pValor };

            var mocRet = new CdbResultado { RendimentoBruto = pValorBruto, RendimentoLiquido = pValorLiquido, ValorResgate = pValor };
            _Service.Calcular(req).Returns(mocRet);

            var result = target.Calcular(req);
            var ret = (result as OkObjectResult)?.Value as CdbResultado;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(ret);
            Assert.Equal(pValorBruto, ret.RendimentoBruto);
            Assert.Equal(pValorLiquido, ret.RendimentoLiquido);
            Assert.Equal(pValor, ret.ValorResgate);
            _Service.Received(1).Calcular(req);
        }

        [Fact]
        public void Calcular_Shoud_BadRequestNull()
        {
            var target = CreateTarget();
            var result = target.Calcular(null);

            Assert.NotNull(result);
            var msg = (result as BadRequestObjectResult)?.Value;
            Assert.Equal(CalculoCdbService.PARAM_NULL, msg);
        }

        [Theory]
        [InlineData(0, 0, CalculoCdbService.VALOR_INVALIDO)]
        [InlineData(0, 200, CalculoCdbService.MESES_INVALIDO)]
        public void Calcular_Shoud_BadRequest(int pMes, int pValor, string pErro)
        {
            var target = CreateTarget();
            var req = new CdbEntrada { Meses = pMes, Valor = pValor };

            var result = target.Calcular(req);

            Assert.NotNull(result);
            var msg = (result as BadRequestObjectResult)?.Value;
            Assert.Equal(pErro, msg);
        }

        private CdbController CreateTarget()
        {
            _Logger.ClearReceivedCalls();
            _Cache.ClearReceivedCalls();
            _Service.ClearReceivedCalls();
            var target = new CdbController(_Service);
            var context = new DefaultHttpContext
            {
                User = new GenericPrincipal(new GenericIdentity("username"), Array.Empty<string>())
            };
            var contextController = new ControllerContext() { HttpContext = context };
            target.ControllerContext = contextController;
            return target;
        }
    }
}