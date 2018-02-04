using Loteria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoteriaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var megaSena = new MegaSena();
            for (var i = 0; i < 30000; i++)
            {
                megaSena.RegistrarJogo(megaSena.GerarNumerosAleatorios());
                megaSena.RegistrarJogoAutomatico();
            }

            var numerosSorteados = megaSena.GerarNumerosAleatorios();
            var ganhadores = megaSena.Acertadores((List<int>)numerosSorteados);

            Console.WriteLine($"Números sorteados: {string.Join(",", numerosSorteados.OrderBy(a => a).ToList())}.");            
            Console.WriteLine();

            foreach (var item in ganhadores)
            {
                Console.WriteLine($"Dezendas: {item.Key} - Número de bilhetes premiados: {item.Value.Count()}");
                foreach (var n in item.Value)
                {
                    Console.WriteLine($"Bilhete: {n.Id.ToString().PadLeft(6, '0')} - {n.DataHoraJogo} - {string.Join(",", n.GetNumeros().OrderBy(a => a).ToList())}");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
    
}
