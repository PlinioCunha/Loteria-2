using Loteria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loteria.Domain
{
    //public abstract class Jogo : IJogo
    public class Jogo : Validacao, IJogo
    {
        #region Attributes

        private List<Bilhete> _bilhetes;
        private int _qtdNumeros { get; set; }
        private int _numeroMaximo { get; set; }

        #endregion


        #region Constructor

        public Jogo()
        {
            this._bilhetes = new List<Bilhete>();
            this._qtdNumeros = 0;
            this._numeroMaximo = 0;
        }

        #endregion


        #region Methods

        public IEnumerable<int> GerarNumerosAleatorios(int qtdNumeros, int numeroMaximo)
        {
            List<int> numerosGerados = new List<int>();
            int random = 0, i = 0;

            while (i < qtdNumeros)
            {
                random = new Random().Next(1, numeroMaximo);
                if (!numerosGerados.Contains(random))
                {
                    numerosGerados.Add(random);
                    i++;
                }
            }

            return numerosGerados;
        }

        public void CriarJogo(Bilhete bilhete)
        {
            ValidarEntradaBilhete(bilhete);
            this._bilhetes.Add(bilhete);            
        }

        public void CriarJogoAutomatico(Bilhete bilhete)
        {
            bilhete.SetNumeros(GerarNumerosAleatorios(bilhete.QtdNumeros, bilhete.NumeroMaximo));
            ValidarEntradaBilhete(bilhete);
            this.CriarJogo(bilhete);
        }               

        public Dictionary<int, List<Bilhete>> VerificarAcertadores(IEnumerable<Bilhete> bilhetes, List<int> numerosSorteados, int[] dezenasAcertadores)
        {
            Dictionary<int, List<Bilhete>> acertadores = new Dictionary<int, List<Bilhete>>();
            for (var i = 0; i < dezenasAcertadores.Length; i++)
            {
                acertadores.Add(dezenasAcertadores[i], new List<Bilhete>());
            }

            for (int i = 0; i < bilhetes.Count(); i++)
            {
                var numerosBilhete = bilhetes.ElementAt(i).GetNumeros().ToList();
                int qtdAcertos = 0;

                for (int j = 0; j < numerosBilhete.Count; j++)
                {
                    for (int k = 0; k < numerosSorteados.Count; k++)
                    {
                        if (numerosBilhete[j] == numerosSorteados[k])
                            qtdAcertos++;
                    }
                }

                for (int m = 0; m < dezenasAcertadores.Length; m++)
                {
                    if (qtdAcertos == dezenasAcertadores[m])
                        acertadores[dezenasAcertadores[m]].Add(bilhetes.ElementAt(i));

                }
            }

            return acertadores;
        }

        public IEnumerable<Bilhete> GetBilhetes()
        {
            return this._bilhetes;
        }

        #endregion

    }
}

