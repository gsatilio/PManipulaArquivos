using System.IO;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        //string path = "C:\\Dados\\"; // forma diferente
        string path = @"C:\Dados\";
        string file = "arquivo.txt";
        string texto = "";
        // Verifica se diretório existe
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        // Verifica se arquivo existe. Se existe, variavel string recebe conteudo do arquivo
        if (File.Exists(path + file))
        {
            // Carrega o conteudo do arquivo
            StreamReader sr = new(path + file);
            texto = sr.ReadToEnd();
            sr.Close();
            Console.WriteLine("Conteudo do arquivo:");
            Console.WriteLine(texto);
            Console.WriteLine("--------------------");
            // Verifica se o arquio está vazio, se não, pula uma linha
            if (new FileInfo(path + file).Length != 0)
            {
                texto += "\n";
            }
        }

        Console.WriteLine("Informe seu nome:");
        texto += Console.ReadLine();
        Console.WriteLine("Informe seu email:");
        texto += "\n" + Console.ReadLine();
        Console.WriteLine("Informe sua idade:");
        texto += "\n" + Console.ReadLine();

        // Variavel string contatena com as novas informações
        StreamWriter sw = new(path + file);
        sw.WriteLine(texto);
        sw.Close();

        chooseReadLine(path, file); // Imprime a linha selecionada
        Console.ReadKey();
    }
    static void chooseReadLine(string path, string file)
    {
        int linha = 0;
        string s = "";
        Console.WriteLine("Qual linha deseja imprimir?");
        linha = int.Parse(Console.ReadLine());
        StreamReader srf = new(path + file);

        for (int i = 0; i < linha; i++)
        {
            s = srf.ReadLine();
        }
        Console.WriteLine("Linha impressa:  " + s);
        srf.Close();
        
        /* // Exemplo com foreach
        int item = 0;
        foreach(string linha in File.ReadLines(path + file))
        {
            item++;
            if(item == 3)
            {
                Console.WriteLine(linha);
            }
        }
        */
    }
}