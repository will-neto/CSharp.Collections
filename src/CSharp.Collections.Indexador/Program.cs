using CSharp.Collections.Indexador.Exemplo1;

namespace CSharp.Collections.Indexador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClasseIndexadaCustomizada<int> classeIndexada = new ClasseIndexadaCustomizada<int>(4);

            classeIndexada.Adicionar(100);
            classeIndexada.Adicionar(200);
            classeIndexada.Adicionar(300);
            classeIndexada.Adicionar(400);

            for (var i = 0; i < classeIndexada.Tamanho; i++)
            {
                Console.WriteLine(classeIndexada[i]);
            }

            try
            {
                // Dispara erro devido lista ter tamanho fixo de 4
                classeIndexada.Adicionar(500);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            ClasseIndexadaCustomizada<string> classeIndexada2 = new ClasseIndexadaCustomizada<string>(4);

            classeIndexada2.Adicionar("Eu ");
            classeIndexada2.Adicionar("te ");
            classeIndexada2.Adicionar("amo!");

            Console.WriteLine("\n\n");

            for (var i = 0; i < classeIndexada2.Tamanho; i++)
            {
                var texto = classeIndexada2[i] ?? "";
                Console.Write(texto);
            }

        }
    }
}
