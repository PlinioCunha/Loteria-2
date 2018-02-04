using System;
using System.Collections.Generic;
using System.Linq;

namespace Loteria.Domain
{
    public class Validacao
    {

        #region Mensagens de erros

        public const string MSG_VERIFICAR_INTERVALO = "Você deve escolher números entre 1 à {}.";
        public const string MSG_VERIFICAR_QUANTIDADE_NUMEROS = "Você deve escolher {} números.";
        public const string MSG_VERIFICAR_NUMEROS_REPETIDOS = "Não é permitido escolher números repetidos.";

        #endregion


        #region Public Methods

        public void ValidarEntradaBilhete(Bilhete bilhete)
        {
            List<string> erros = new List<string>();

            if (!VerificarRepetidos(bilhete.GetNumeros()))
                erros.Add(MSG_VERIFICAR_INTERVALO.Replace("{}", Convert.ToString(bilhete.NumeroMaximo)));

            if (!VerificarQuantidadeNumeros(bilhete.GetNumeros(), bilhete.QtdNumeros))
                erros.Add(MSG_VERIFICAR_QUANTIDADE_NUMEROS.Replace("{}", Convert.ToString(bilhete.QtdNumeros)));

            if (!VerificarIntervalo(bilhete.GetNumeros(), bilhete.NumeroMaximo))
                erros.Add(MSG_VERIFICAR_QUANTIDADE_NUMEROS.Replace("{}", Convert.ToString(bilhete.NumeroMaximo)));

            if (erros.Count > 0)
                throw new Exception(string.Join(" - ", erros));
        }






        public bool VerificarRepetidos(IEnumerable<int> numeros)
        {
            return !numeros.GroupBy(a => a).Any(a => a.Count() > 1);
        }

        public bool VerificarQuantidadeNumeros(IEnumerable<int> numeros, int qtdNumeros)
        {
            return numeros.Count().Equals(qtdNumeros);
        }

        public bool VerificarIntervalo(IEnumerable<int> numeros, int numeroMaximo)
        {
            return (numeros.Min() > 0 && numeros.Max() <= numeroMaximo);

        }

        #endregion


    }
}
