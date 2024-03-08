
using System;

using Models;
using Models.Interfaces;

using Services.Cache;
using Services.Interfaces;

using Toolkit;

namespace Services.Services
{
    /// <summary>
    /// Service que a finalizade
    /// </summary>
    public class CalculoCdbService : ICalculoCdbService
    {
        /// <summary>
        /// Construtror que recebe o cache via Injection
        /// </summary>
        /// <param name="pCache"></param>
        public CalculoCdbService(IDataCache pCache = null)
        {
            _Cache = pCache;
        }
        private IDataCache _Cache;

        /// <summary>
        /// Mensagem para Parâmetro Nulo
        /// </summary>
        public const string PARAM_NULL = "O parâmetro [pPars] não pode ser nulo.";

        /// <summary>
        /// Mensagem para Campo Meses inválido
        /// </summary>
        public const string MESES_INVALIDO = "O valor do Campo [Meses] deve estar entre 1 e 750.";

        /// <summary>
        /// Mensagem para Campo Valor inválido
        /// </summary>
        public const string VALOR_INVALIDO = "O valor do Campo [Valor] deve estar entre 1 e 2.147.483.647.";

        /// <summary>
        /// Calcula CDB segundo os parâmetros informados
        /// </summary>
        /// <param name="pPars"></param>
        /// <returns></returns>
        public CdbResultado Calcular(CdbEntrada pPars)
        {
            if (pPars == null)
                throw new MyException(PARAM_NULL);
            if (pPars.Valor <= 0)
                throw new MyException(VALOR_INVALIDO);
            if (pPars.Meses <= 1)
                throw new MyException(MESES_INVALIDO);

            var ret = new CdbResultado();
            var ini = DateTime.Now.AddMonths(-1 * pPars.Meses);
            decimal vi = pPars.Valor;
            for (int i = 0; i < pPars.Meses; i++)
            {
                var cdi = _Cache.GetCDI(ini.Month, ini.Year);
                var tb = _Cache.GetTB(ini.Month, ini.Year);
                vi *= (1 + (cdi / 100 * tb / 100));
                ini = ini.AddMonths(1);
            }
            var ir = _Cache.GetIR(pPars.Meses) / 100;
            ret.RendimentoBruto = vi - pPars.Valor;
            ret.RendimentoLiquido = ret.RendimentoBruto - ret.RendimentoBruto * ir;
            ret.ValorResgate = pPars.Valor;
            return ret;
        }

        /// <summary>
        /// Calcula CDB segundo os parâmetros informados, versão simples
        /// </summary>
        /// <param name="pPars"></param>
        /// <returns></returns>
        public CdbResultado CalcularSimples(CdbEntrada pPars)
        {
            if (pPars == null)
                throw new MyException(PARAM_NULL);
            if (pPars.Valor <= 0)
                throw new MyException(VALOR_INVALIDO);
            if (pPars.Meses <= 1)
                throw new MyException(MESES_INVALIDO);

            var ret = new CdbResultado();
            decimal vi = pPars.Valor;
            for (int i = 0; i < pPars.Meses; i++)
            {
                vi *= (1 + (DataCache.CDI / 100 * DataCache.TB / 100));
            }
            var ir = _Cache.GetIR(pPars.Meses) / 100;
            ret.RendimentoBruto = vi - pPars.Valor;
            ret.RendimentoLiquido = ret.RendimentoBruto - ret.RendimentoBruto * ir;
            ret.ValorResgate = pPars.Valor;
            return ret;
        }
        /// <summary>
        /// Atribuição do Cache que o serviço usará
        /// </summary>
        /// <param name="pCache"></param>
        public void SetCache(IDataCache pCache)
        {
            _Cache = pCache;
        }
    }
}
