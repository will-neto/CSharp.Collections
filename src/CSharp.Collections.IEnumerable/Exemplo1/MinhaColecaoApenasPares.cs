using System.Collections;
using System.Collections.ObjectModel;


namespace CSharp.Collections.IEnumerable.Exemplo1
{
    /*
        Criação da coleção implementando IEnumerable
     */
    public class MinhaColecaoApenasPares : System.Collections.IEnumerable
    {
        private List<int> items = new List<int>();

        public MinhaColecaoApenasPares()
        {

        }

        public void Adicionar(params int[] numeros)
        {
            items.AddRange(numeros);
        }

        // Implementação do método da IEnumerable através de uma classe concreta customizada para a IEnumerator
        public IEnumerator GetEnumerator()
        {
            return new EnumeradorCustomizado(this);
        }

        // Classe concreta customizada que implementa IEnumerator e possui a lógica própria de iteração
        public class EnumeradorCustomizado : IEnumerator
        {
            public EnumeradorCustomizado(MinhaColecaoApenasPares minhaColecaoCustomizada)
            {
                _minhaColecaoCustomizada = minhaColecaoCustomizada;
            }

            private readonly MinhaColecaoApenasPares _minhaColecaoCustomizada;
            private int _indice = -1;

            public object Current => _minhaColecaoCustomizada.items[_indice];

            // Método de iteração
            // Adicionada regra que retorna apenas números pares, em caso do indice não existir, irá disparar uma exception 
            // que finalizará a operação
            public bool MoveNext()
            {
                try
                {
                    do
                    {
                        _indice++;
                    }
                    while (_minhaColecaoCustomizada.items[_indice] % 2 != 0);

                    return _indice < _minhaColecaoCustomizada.items.Count;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("== FIM ==");
                }

                return false;
            }

            public void Reset()
            {
                _indice = -1;
            }
        }
    }
}
