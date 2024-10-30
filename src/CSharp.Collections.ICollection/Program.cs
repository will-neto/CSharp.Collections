using CSharp.Collections.Collection.Exemplo1;
using CSharp.Collections.Collection.Exemplo2;

namespace CSharp.Collections.Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Collection();
            CollectionGenerica();
        }

        private static void Collection()
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
            System.Collections.ICollection colecao = lista;

            foreach(var item in colecao)
            {
                Console.WriteLine(item);
            }

        }

        //TODO: criação de classe customizada de collection generica 
        private static void CollectionGenerica()
        {
            /* 
                Devido a introdução de genéricos, a ICollection<T> (genérica) possui métodos adicionais para persistência
                de dados. Isso se dá devido a segurança de tipo, onde o tipo informado é único para a ICollection<T>, já para a 
                ICollection não-genérica, seria necessário utilizar "objects", o que possui mais complexidade devido a necessidade de
                casting e também amplia a margem de possíveis erros.
            */

            MinhaCollectionGenericaCustomizada<int> minhaListaNumeros = new MinhaCollectionGenericaCustomizada<int>();
            minhaListaNumeros.Add(10);
            minhaListaNumeros.Add(20);
            minhaListaNumeros.Add(30);
            minhaListaNumeros.Add(40);

            foreach (var item in minhaListaNumeros)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Lógica de redimensionamento em caso de inclusão acima do tamanho");

            minhaListaNumeros.Add(50);

            foreach (var item in minhaListaNumeros)
            {
                Console.WriteLine(item);
            }

            minhaListaNumeros.Remove(50);


        }
    }
}
