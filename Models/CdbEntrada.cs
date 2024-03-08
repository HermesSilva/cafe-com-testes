using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// Parâmetros de entrada para cáculo de CDB
    /// </summary>
    public class CdbEntrada
    {
        /// <summary>
        /// Quantidade de meses, maior que zero (0), reprsentando o prazo do resgate 
        /// </summary>

        [DefaultValue(0)]
        [Range(2, 750, ErrorMessage = $"O valor deste campo deve estar entre 1 e 750")]
        public int Meses { get; set; }

        /// <summary>
        /// Valor monetário, maior que  zero (0), coorespondente ao valor aplicado.
        /// </summary>
        [DefaultValue(0)]
        [Range(1, int.MaxValue, ErrorMessage = $"O valor deste campo deve estar entre 1 e 100.000.000,00")]
        public decimal Valor { get; set; }

    }
}
