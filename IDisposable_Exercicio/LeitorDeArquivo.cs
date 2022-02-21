namespace IDisposable_Antes;

public class LeitorDeArquivo : IDisposable
{
    public string Arquivo { get; set; }

    public LeitorDeArquivo(string arquivo)
    {
        Arquivo = arquivo;
        Console.WriteLine("Abrindo arquivo " + arquivo);
    }

    public string LerProximaLinha()
    {
        Console.WriteLine("Lendo linha ...");
        throw new IOException();
        return "Linha do arquivo";
    }

    public void Dispose()
    {
        Console.WriteLine("Fechando arquivo");
    }
}