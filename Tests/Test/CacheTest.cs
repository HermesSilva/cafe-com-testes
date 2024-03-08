using System.Diagnostics.CodeAnalysis;

using Services.Cache;

using Toolkit;

namespace Test
{
    [ExcludeFromCodeCoverage]
    public class CacheTest
    {
        [Theory]
        [InlineData(1, 22.5)]
        [InlineData(6, 22.5)]
        [InlineData(9, 20)]
        [InlineData(12, 20)]
        [InlineData(22, 17.5)]
        [InlineData(24, 17.5)]
        [InlineData(26, 15)]
        [InlineData(36, 15)]
        public void GetIR_ShouldOk(int pMeses, decimal pValor)
        {
            var cache = new DataCache();
            Assert.Equal(pValor, cache.GetIR(pMeses));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetIR_ShouldMesesInvalido(int pMeses)
        {
            var cache = new DataCache();
            var ex = Assert.Throws<MyException>(() => cache.GetIR(pMeses));
            Assert.Equal(DataCache.MESES_INVALIDO, ex.Message);
        }


        [Theory]
        [InlineData(0, -1)]
        [InlineData(-1, 1950)]
        [InlineData(13, 0)]
        [InlineData(-1, 0)]
        public void GetCDI_Should_MesInvalido(int pMes, int pAno)
        {
            var cache = new DataCache();
            var ex = Assert.Throws<MyException>(() => cache.GetCDI(pMes, pAno));
            Assert.Equal(DataCache.MES_INVALIDO, ex.Message);
        }

        [Theory]
        [InlineData(1, -1)]
        [InlineData(2, 0)]
        [InlineData(11, 1959)]
        [InlineData(3, 2025)]
        public void GetCDI_Should_AnoInvalido(int pMes, int pAno)
        {
            var cache = new DataCache();
            var ex = Assert.Throws<MyException>(() => cache.GetCDI(pMes, pAno));
            Assert.Equal(DataCache.ANO_INVALIDO, ex.Message);
        }


        [Theory]
        [InlineData(0, -1)]
        [InlineData(-1, 1950)]
        [InlineData(13, 0)]
        [InlineData(-1, 0)]
        public void GetTB_Should_MesInvalido(int pMes, int pAno)
        {
            var cache = new DataCache();
            var ex = Assert.Throws<MyException>(() => cache.GetTB(pMes, pAno));
            Assert.Equal(DataCache.MES_INVALIDO, ex.Message);
        }
        
        [Theory]
        [InlineData(1, -1)]
        [InlineData(2, 0)]
        [InlineData(11, 1959)]
        [InlineData(3, 2025)]
        public void GetTB_Should_AnoInvalido(int pMes, int pAno)
        {
            var cache = new DataCache();
            var ex = Assert.Throws<MyException>(() => cache.GetTB(pMes, pAno));
            Assert.Equal(DataCache.ANO_INVALIDO, ex.Message);
        }


        [Theory]
        [InlineData(1, 1960, 108)]
        [InlineData(2, 1960, 108)]
        [InlineData(8, 1985, 108)]
        [InlineData(7, 2000, 108)]
        [InlineData(1, 2021, 108)]
        [InlineData(2, 2023, 108)]
        [InlineData(11, 2024, 108)]
        public void GetCDI_Should_MesAnoValido(int pMes, int pAno, decimal pCDI)
        {
            var cache = new DataCache();
            var cdi = cache.GetCDI(pMes, pAno);
            Assert.Equal(pCDI, cdi);
            cdi = cache.GetCDI(pMes, pAno);
            Assert.Equal(pCDI, cdi);
        }

        [Theory]
        [InlineData(1, 1960, 0)]
        [InlineData(2, 1960, -1)]
        [InlineData(8, 1985, 100)]
        public void GetCDI_Should_Valor(int pMes, int pAno, decimal pCDI)
        {
            var cache = new DataCache();
            var cdi = cache.GetCDI(pMes, pAno);
            Assert.NotEqual(pCDI, cdi);
        }

        [Theory]
        [InlineData(1, 1960, 0.9)]
        [InlineData(2, 1960, 0.9)]
        [InlineData(8, 1985, 0.9)]
        [InlineData(7, 2000, 0.9)]
        [InlineData(1, 2021, 0.9)]
        [InlineData(2, 2023, 0.9)]
        [InlineData(11, 2024, 0.9)]
        public void GetTB_Should_Valido(int pMes, int pAno, decimal pCDI)
        {
            var cache = new DataCache();
            var cdi = cache.GetTB(pMes, pAno);
            Assert.Equal(pCDI, cdi);
            cdi = cache.GetTB(pMes, pAno); // Para teste do uso de valores em cache
            Assert.Equal(pCDI, cdi);
        }
    }
}