using CSharp.Collections.Collection.Exemplo1;
using System.Collections;

namespace CSharp.Collections.Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICollection();
            ICollectionGenerica();
        }

        private static void ICollection()
        {
            /*
                - A "ICollection" é uma interface não-genérica que implementa a interface "IEnumerable";
                - Permite qualquer tipo de objeto (assim como a IEnumerable); 
                - Criada para ser uma abstração para uso por outras interfaces (IList, IDictionary) ou classes concretas
                    (Queue, Stack, BitArray) possam estender suas funcionalidades;

                - IList possui uma lista de métodos de controles que devem ser implementadas pelas classes concretas
             */

            // Exemplo de classe concreta customizada herdando IList
            MinhaCollectionCustomizada lista = new MinhaCollectionCustomizada(10);
            lista.Adicionar(10, 20, 65, 98, 7, 977, 546);
            ICollection colecao = lista;

            foreach(var item in colecao)
            {
                Console.WriteLine(item);
            }
        }

        private static void ICollectionGenerica()
        {

        }
    }
}
