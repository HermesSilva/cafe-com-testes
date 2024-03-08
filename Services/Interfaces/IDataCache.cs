namespace Services.Interfaces
{
    /// <summary>
    /// Interface para cache de dados
    /// </summary>
    public interface IDataCache
    {
        /// <summary>
        /// Informado mês e ano será retornado o valor da Taxa.
        /// </summary>
        /// <param name="pMes"></param>
        /// <param name="pAno"></param>
        /// <returns></returns>
        decimal GetCDI(int pMes, int pAno);

        /// <summary>
        /// Retorna tara do IR com base na quantidade de meses
        /// </summary>
        /// <param name="pMeses"></param>
        /// <returns></returns>
        decimal GetIR(int pMeses);

        /// <summary>
        /// Retorna a Taxa Básica armazenada em Cache ou busca uma nova no serviço designado e armazena no cache.
        /// </summary>
        /// <param name="pMes"></param>
        /// <param name="pAno"></param>
        /// <returns></returns>
        decimal GetTB( int pMes, int pAno);
        
    }
}
