using System;
using System.Collections.Generic;

using Services.Interfaces;

using Toolkit;

namespace Services.Cache
{
    /// <summary>
    /// Esta classe é destinada a manter os dados não mutáveis que foram carregado de algum recurso
    /// </summary>
    public class DataCache : IDataCache
    {
        /// <summary>
        /// Taxa básica
        /// </summary>
        public const decimal TB = 0.9M;
        /// <summary>
        /// Taxa do CDI
        /// </summary>
        public const decimal CDI = 108M;
        private const int _PRIMEIRO_MES_ANO = 1;
        private const int _ULTIMO_MES_ANO = 12;
        private const int _MENOR_ANO_CDI = 1960;

        /// <summary>
        /// Mensagem de erro para mês inválido
        /// </summary>
        public const string MES_INVALIDO = "O parâmetro [pMes] deve ter um valor entre 1 e 12";
        /// <summary>
        /// Mensagem de erro para Ano inválido
        /// </summary>
        public const string ANO_INVALIDO = "O parâmetro [pAno] deve ter um valor entre 1960 e 2024";
        /// <summary>
        /// Mensagem de erro para Quantidade de meses invalida
        /// </summary>
        public const string MESES_INVALIDO = "O parâmetro [pMeses] deve ter um valor maior que zero";


        private static readonly int _MAIOR_ANO_CDI = DateTime.Now.Year;
        private readonly Dictionary<string, decimal> _CDICache = new Dictionary<string, decimal>();
        private readonly Dictionary<string, decimal> _TBCache = new Dictionary<string, decimal>();

        /// <summary>
        /// Informado mês e ano será retornado o valor da Taxa.
        /// </summary>
        /// <param name="pMes"></param>
        /// <param name="pAno"></param>
        /// <returns></returns>
        public decimal GetCDI(int pMes, int pAno)
        {
            if (pMes < _PRIMEIRO_MES_ANO || pMes > _ULTIMO_MES_ANO)
                throw new MyException(MES_INVALIDO);
            if (pAno < _MENOR_ANO_CDI || pAno > _MAIOR_ANO_CDI)
                throw new MyException(ANO_INVALIDO);
            var key = pMes.ToString("00") + pAno.ToString("0000");
            if (_CDICache.TryGetValue(key, out var cDI))
                return cDI;
            _CDICache[key] = CDI;
            return CDI;
        }

        /// <summary>
        /// Retorna tara do IR com base na quantidade de meses
        /// </summary>
        /// <param name="pMeses"></param>
        /// <returns></returns>
        /// <exception cref="MyException"></exception>
        public decimal GetIR(int pMeses)
        {
            if (pMeses <= 0)
                throw new MyException(MESES_INVALIDO);
            switch (pMeses)
            {
                case <= 6:
                    return 22.5M;
                case <= 12:
                    return 20M;
                case <= 24:
                    return 17.5M;
                default:
                    return 15;
            }
        }

        /// <summary>
        /// Retorna a Taxa Básica armazenada em Cache ou busca uma nova no serviço designado e armazena no cache.
        /// </summary>
        /// <param name="pMes"></param>
        /// <param name="pAno"></param>
        /// <returns></returns>
        public decimal GetTB(int pMes, int pAno)
        {
            if (pMes < _PRIMEIRO_MES_ANO || pMes > _ULTIMO_MES_ANO)
                throw new MyException(MES_INVALIDO);
            if (pAno < _MENOR_ANO_CDI || pAno > _MAIOR_ANO_CDI)
                throw new MyException(ANO_INVALIDO);
            var key = pMes.ToString("00") + pAno.ToString("0000");
            if (_TBCache.TryGetValue(key, out var cTB))
                return cTB;
            _TBCache[key] = TB;
            return TB;
        }
    }
}
