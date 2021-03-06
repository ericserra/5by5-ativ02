﻿using System;
using System.Globalization;

namespace Covid_19
{
    class Paciente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public bool Comorbidade { get; set; }
        public DateTime DataInicialSintomas { get; set; }
        public bool Covid { get; set; }
        public DateTime Periodo { get; set; }
        public Paciente Proximo { get; set; }

        public int Idade()
        {
            int idade;
            if ((DateTime.Now.Month == DataNascimento.Month))
            {
                if ((DateTime.Now.Day < DataNascimento.Day))
                {

                    idade = DateTime.Now.Year - DataNascimento.Year - 1;
                }
                else
                {
                    idade = DateTime.Now.Year - DataNascimento.Year;
                }
            }
            if ((DateTime.Now.Month < DataNascimento.Month))
            {

                idade = DateTime.Now.Year - DataNascimento.Year - 1;
            }
            else
            {
                idade = DateTime.Now.Year - DataNascimento.Year;
            }
            return idade;
        }

        public void VerificaStatus()
        {
            string resultado = "";
            do
            {
                Console.Write("O exame deu positivo?[s/n]: ");
                resultado = Console.ReadLine().ToUpper();

                if (resultado == "S")
                {
                    Covid = true;
                }
                else if (resultado == "N")
                {
                    Covid = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("VOCÊ DEVE DIGITAR APENAS [S] OU [N]!!\n");
                    Console.ResetColor();
                } 
            } while (resultado != "S" && resultado != "N");
        }
        public void Importancia()
        {
            Console.Clear();
            string resposta;

            Console.Write("O paciente possui comorbidades[s/n]?: ");
            resposta = Console.ReadLine();

            if (resposta.ToUpper() == "S")
            {
                Comorbidade = true;
            }
            else
            {
                Comorbidade = false;
            }

            Console.Write("Qual a data inicial dos sintomas?: ");
            Periodo = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public override string ToString()
        {
            return $"\nCPF: {CPF}\n" +
                   $"Nome: {Nome}\n" +
                   $"Data de nacimento: {DataNascimento.ToString("dd/MM/yyyy")}\n" +
                   $"Telefone: {Telefone}\n";
        }
    }
}
