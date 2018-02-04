using System;
using System.Collections.Generic;
using System.Text;

namespace Loteria.Domain.Interfaces
{
    public interface IJogo
    {
        void CriarJogo(Bilhete bilhete);
        void CriarJogoAutomatico(Bilhete bilhete);

        //IEnumerable<int> SortearNumeros();
        IEnumerable<int> GerarNumerosAleatorios(int qtdNumeros, int numeroMaximo);

        IEnumerable<Bilhete> GetBilhetes();
        Dictionary<int, List<Bilhete>> VerificarAcertadores(IEnumerable<Bilhete> bilhetes, List<int> numerosSorteados, int[] dezenasAcertadores);

    }
}
