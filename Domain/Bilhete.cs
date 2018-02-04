using System;
using System.Collections.Generic;
using System.Linq;

namespace Loteria.Domain
{
    public class Bilhete : Validacao
    {

        public enum NomeJogo
        {
            MegaSena,
            LotoFacil
        }


        #region Constructor

        public Bilhete(IEnumerable<int> numeros, NomeJogo nomeJogo, int qtdNumeros, int numeroMaximo)
        {           
            this.Id = GenereteId();
            this.DataHoraJogo = DateTime.Now;
            this.Tipo = nomeJogo;
            this.QtdNumeros = qtdNumeros;
            this.NumeroMaximo = numeroMaximo;
           
            this.Numeros = numeros;
        }

        #endregion


        #region Attributtes

        private static int seed = 1;

        public Int32 Id { get; internal set; }
        public NomeJogo Tipo { get; set; }
        public DateTime DataHoraJogo { get; set; }
        public int QtdNumeros { get; set; }
        public int NumeroMaximo { get; set; }

        private IEnumerable<int> Numeros { get; set; }

        #endregion

        
        #region Methods 
        private int GenereteId()
        {
            return Bilhete.seed++;
        }

        public IEnumerable<int> GetNumeros()
        {
            return this.Numeros.ToList();
        }

        public void SetNumeros(IEnumerable<int> numeros)
        {
            this.Numeros = numeros;
        }
        #endregion
        
    }
}
