﻿using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for(int i=0; i < tab.linhas; i++)
            {
                //coloca o número da linha antes de imprimir a linha no tabuleiro
                Console.Write(8 - i + " ");

                for(int j = 0; j < tab.colunas; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }

            Console.WriteLine("   a  b  c  d  e  f  g  h");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlternativo = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                //coloca o número da linha antes de imprimir a linha no tabuleiro
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlternativo;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }

            Console.WriteLine("   a  b  c  d  e  f  g  h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }


        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write(" - ");
            }
            else
            {

                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    //grava a cor original das letras do console
                    ConsoleColor aux = Console.ForegroundColor;
                    //altera a cor do objeto a ser impresso
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    //retorna a cor original para que o próximo objeto tenha a cor original
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
