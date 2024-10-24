using CSharp.Collections.IEnumerable.Exemplo1;

namespace CSharp.Collections.IEnumerable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                - IEnumerable e IEnumerable<T> são as interfaces principal
                - Ambas possuem a declaração do método GetEnumerator() : IEnumerator
                - Definem a interface básica para "transformar" uma classe concreta em coleção

                - Por que não usar apenas uma interface como IEnumerator já que a mesma já possui a implementação de métodos
                que uma coleção que utilizar IEnumerable precisará para funcionar?
                    A resposta está justamento no SRP (Single Reponsability Principle - Principio de Responsabilidade Única), onde
                    por convenção o ideal é separar a utilidade das duas classes. Por um lado, a IEnumerable nos indica que uma classe
                    é parte de uma coleção e pode ser iterada, já a IEnumerator define o comportamento da iteração

             */


            System.Collections.IEnumerable colecaoCustomizada = new MinhaColecaoApenasPares();

            ((MinhaColecaoApenasPares) colecaoCustomizada).Adicionar(10, 11, 12, 123, 4654, 45698, 456, 4646);

            Console.WriteLine("== Números Pares (IEnumerable) ==");
                
            foreach(var item in colecaoCustomizada)
            {
               Console.WriteLine("• " + item);
            }

            Console.WriteLine("\n\n\n\n");


            System.Collections.IEnumerable colecaoCustomizada2 = new MinhaColecaoApenasIndexPares<string>(
                "PAR 1", "IMPAR 1", "PAR 2", "IMPAR 2", "PAR 3", "IMPAR 3");

            Console.WriteLine("== INDEX PARES (IEnumerable<T>) ==");

            foreach (var item in colecaoCustomizada2)
            {
                Console.WriteLine("• " + item);
            }

        }
    }
}
