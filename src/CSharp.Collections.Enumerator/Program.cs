using CSharp.Collections.IEnumerator.Exemplo1;
using System.Collections;

namespace CSharp.Collections.I0Enumerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Enumerator();

            ColecaoCustomizadaExemplo();
        }


        private static void Enumerator()
        {
            /*
               - Interface IEnumerator é usada para permitir o looping via foreach em classes que utilizam a mesma. 
               Internamente, o "foreach" utiliza o GetEnumerator() para seu funcionamento

               - Um exemplo são as interfaces IEnumerable e IEnumerable<T>, ambas possuem a declaração do método GetEnumerator,
               que retorna um IEnumerator
            
                - Reforçando apenas o conceito de que implementar o GetEnumerator() para habilitar o uso no foreach não a transforma
                em uma classe de coleção. Para a classe ser considerada uma coleção deve herdar o IEnumerable/IEnumerable<T>
             */

            IEnumerable<int> numeros = new List<int>() { 10, 2, 3, 5 };
            IEnumerable caracteres = new ArrayList { 11, "teste", 2L, 3F, 1D };
            IEnumerable<int> numeros2 = new Queue<int>(new int[] { 12, 2, 3, 4, 5 });

            // Possui o método GetEnumerator() com implementação através de cada um dos tipos concretos

            var numerosEnumerador = numeros.GetEnumerator();
            var caracteressEnumerador = caracteres.GetEnumerator();
            var numeros2Enumerador = numeros2.GetEnumerator();

            // As classes concretas que implementam o GetEnumerator() retornam uma instancia nova sempre que chamado o método
            // Algumas podem disparar erros caso não seja chamado o método MoveNext();
            numeros.GetEnumerator().MoveNext();
            caracteressEnumerador.MoveNext();
            numeros2Enumerador.MoveNext();

            Console.WriteLine("numeros (List<int>) = " + numerosEnumerador.Current); // Não dispara erro se nao chamado MoveNext() antes de usar Current
            Console.WriteLine("caracteres (ArrayList) = " + caracteressEnumerador.Current); // Dispara erro se nao chamado MoveNext() antes de usar Current
            Console.WriteLine("numeros (Queue<int>) = " + numeros2Enumerador.Current); // Dispara erro se nao chamado MoveNext() antes de usar Current

            numerosEnumerador.MoveNext();
            Console.WriteLine("numeros (List<int>) = " + numerosEnumerador.Current); // Não dispara erro se nao chamado MoveNext() antes de usar Current


        }


        private static void ColecaoCustomizadaExemplo()
        {
            EnumeradorCustomizado<int> colecaoCustomizada = new EnumeradorCustomizado<int>(1,2,3,4,5,6);

            // Percorre a instância da classe de enumerador customizada devido a implementação dos métodos necessários que permitem
            // tal abordagem
            Console.WriteLine("\n\nEnumerador Customizado com implementação de GetEnumerator()");
            foreach(var item in colecaoCustomizada)
            {
                Console.Write(item + " | ");
            }

            // Não é possível utilizar a instância em um loop for devido a classe não ter sido indexada
            // Exemplo de indexação no CSharp.Collections.Indexador
            //for (var i = 0; i < 10; i++)
            //{
            //    colecaoCustomizada[i];
            //}
        }
    }
}
