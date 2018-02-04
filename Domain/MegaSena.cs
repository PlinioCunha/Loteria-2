using Loteria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Loteria.Domain
{
    public class MegaSena
    {
        #region Attributes

        private Bilhete.NomeJogo _nomeJogo = Bilhete.NomeJogo.MegaSena;

        // Quantidade de números a escolher no jogo da mega sena
        private const int _qtdNumeros = 6;
        // Maior número a se escolher no jogo da mega sena
        private const int _numeroMaximo = 60;
        // Sena, Quina e Quadra.
        private int[] _dezenasAcertadores = {6, 5, 4};

        #endregion


        #region Constructor
        private Bilhete bilhete;
        private readonly IJogo _jogo;
        public MegaSena()
        {
            var serviceProvider = new ServiceCollection()           
                .AddSingleton<IJogo, Jogo>()           
                .BuildServiceProvider();           
            
            _jogo = serviceProvider.GetService<IJogo>();

            bilhete = new Bilhete(Enumerable.Empty<int>(), Bilhete.NomeJogo.MegaSena, _qtdNumeros, _numeroMaximo);
        }

        #endregion


        #region Methods

        public void RegistrarJogo(IEnumerable<int> numeros)
        {
            var bilhete = new Bilhete(numeros, _nomeJogo, _qtdNumeros, _numeroMaximo);
            _jogo.CriarJogo(bilhete);
        }

        public void RegistrarJogoAutomatico() {
            var bilhete = new Bilhete(Enumerable.Empty<int>(), _nomeJogo, _qtdNumeros, _numeroMaximo);            
            _jogo.CriarJogoAutomatico(bilhete);
        }
        
        public IEnumerable<int> GerarNumerosAleatorios()
        {
            return _jogo.GerarNumerosAleatorios(_qtdNumeros, _numeroMaximo);
        }



        public Dictionary<int, List<Bilhete>> Acertadores(List<int> numerosSorteados)
        {
            return _jogo.VerificarAcertadores(_jogo.GetBilhetes(), numerosSorteados, _dezenasAcertadores);
        }

        #endregion

    }

}
