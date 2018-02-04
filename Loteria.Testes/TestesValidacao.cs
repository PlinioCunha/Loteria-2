using FluentAssertions;
using Loteria.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Loteria.Testes
{
    public class TestesValidacao
    {

        [Theory(DisplayName = nameof(ValidarEntradaBilhete))]
        [ClassData(typeof(ValidacaoTestData))]
        public void ValidarEntradaBilhete(IEnumerable<int> numeros, int qtdNumeros, int numeroMaximo)
        {                       
            var validacao = new Validacao();

            var resultado1 = validacao.VerificarIntervalo(numeros, numeroMaximo);
            resultado1.Should().Be(true, Validacao.MSG_VERIFICAR_INTERVALO.Replace("{}", Convert.ToString(numeroMaximo)));

            var resultado2 = validacao.VerificarQuantidadeNumeros(numeros, qtdNumeros);
            resultado2.Should().Be(true, Validacao.MSG_VERIFICAR_QUANTIDADE_NUMEROS.Replace("{}", Convert.ToString(qtdNumeros)));

            var resultado3 = validacao.VerificarRepetidos(numeros);
            resultado3.Should().Be(true, Validacao.MSG_VERIFICAR_NUMEROS_REPETIDOS);

        }
    }


    public class ValidacaoTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new List<int>() {1, 2, 3, 4, 5, 6, 8 }, 6, 60 };
            yield return new object[] { new List<int>() { 1, 2, 3, 4, 5, 70 }, 6, 60 };
            yield return new object[] { new List<int>() { 0, 2, 3, 4, 5, 6 }, 6, 60 };
            yield return new object[] { new List<int>() { 27, 29, 38, 44, 52, 59 }, 6, 60 };
           
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

