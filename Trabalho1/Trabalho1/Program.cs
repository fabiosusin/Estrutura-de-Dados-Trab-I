using System;
using System.Collections.Generic;
using System.Linq;

namespace Trabalho1
{
    class Program
    {
        public static List<Carta> CartasDeLetras = new() { new Carta("A", 1), new Carta("J", 11), new Carta("Q", 12), new Carta("K", 13) };

        static void Main()
        {
            Console.WriteLine("Implementação de lista usando vetores");
            Console.WriteLine();

            var jogo = new Jogo();
            for (var i = 0; i < 7; i++)
            {
                Console.Write("Digite a carta que você recebeu: ");
                var carta = PegaCarta(Console.ReadLine());
                while (carta == null)
                {
                    Console.WriteLine("Carta inválida digitada!");
                    Console.Write("Digite a carta que você recebeu: ");
                    carta = PegaCarta(Console.ReadLine());
                }

                jogo.RecebeCarta(carta);
            }

            Console.WriteLine("--------------------------------------------");
            jogo.VerListaCartas();

            Console.WriteLine("--------------------------------------------");
            jogo.VerListaCartasInvertida();
        }

        public static Carta PegaCarta(string carta)
        {
            if (!int.TryParse(carta, out var numero))
                return CartasDeLetras.FirstOrDefault(x => x.Nome == carta.ToUpper());

            return numero > 0 && numero < 11 ? new Carta(carta, numero) : null;
        }
    }

    public class Jogo
    {
        public Carta[] Cartas { get; set; } = new Carta[7];
        public void RecebeCarta(Carta novaCarta)
        {
            if (novaCarta == null)
                return;

            var novaCartaPosicao = 0;
            for (var i = 0; i < Cartas.Length; i++)
            {
                if (Cartas[i] == null)
                    break;

                var carta = Cartas[i];
                if (carta.Valor > novaCarta.Valor)
                    break;

                novaCartaPosicao++;
            }

            var novasCartas = new Carta[7];
            novasCartas[novaCartaPosicao] = novaCarta;
            for (var i = 0; i < Cartas.Length; i++)
            {
                var j = i;
                if (novaCartaPosicao <= i)
                    j++;

                if (j == Cartas.Length)
                    break;

                novasCartas[j] = Cartas[i];
            }

            Cartas = novasCartas;
        }

        public void VerListaCartas()
        {
            Console.WriteLine("Suas Cartas são: ");
            foreach (var carta in Cartas)
                Console.WriteLine(carta?.Nome);
        }

        public void VerListaCartasInvertida()
        {
            Console.WriteLine("Suas Cartas Invertidas são:");
            for (var i = Cartas.Length - 1; i >= 0; i--)
                Console.WriteLine(Cartas[i]?.Nome);
        }

    }

    public class Carta
    {
        public Carta(string nome, int valor)
        {
            Valor = valor;
            Nome = nome;
        }

        public int Valor { get; set; }
        public string Nome { get; set; }
    }
}