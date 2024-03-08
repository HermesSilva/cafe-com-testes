namespace Models.Interfaces
{
    /// <summary>
    /// Classe destina ao cáculo do CDB
    /// </summary>
    public interface ICalculoCdbService 
    {
        /// <summary>
        /// Calcula CDB segundo os parâmetros informados
        /// </summary>
        /// <param name="pPars"></param>
        /// <returns></returns>
        CdbResultado Calcular(CdbEntrada pPars);
    }
}
