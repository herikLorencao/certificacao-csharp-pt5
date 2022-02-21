namespace IDisposable_Antes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarregarContas();
        }

        public static void CarregarContas()
        {
            using (LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt"))
            {
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }
        }
    }
}