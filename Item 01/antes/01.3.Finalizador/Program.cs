using System;
using System.Diagnostics;

namespace _01._3.Finalizador_antes
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000000; i++)
            {
                Livro livro = new Livro();
            }

            Console.ReadKey();
        }
    }

    class Livro
    {
        static int UltimoId = 0;
        public string Introducao { get; set; }
        public string Texto { get; set; }
        public string Conclusao { get; set; }
        public int Id { get; }

        public Livro()
        {
            UltimoId++;
            Id = UltimoId;
            Trace.WriteLine("Livro " + Id + " está sendo criado");
        }

        ~Livro()
        {
            // Usar para finalizar recursos não gerenciáveis
            Console.WriteLine($"Livro {Id} finalizado");
        }
    }
}
