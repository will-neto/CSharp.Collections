using System.Collections;

namespace CSharp.Collections.IEnumerable.Exemplo1
{
    /*
        Criação da coleção implementando IEnumerable
     */
    public class MinhaColecaoApenasIndexPares<T> : IEnumerable<T>
    {
        private T[] _items;

        public MinhaColecaoApenasIndexPares(params T[] itens)
        {
            _items = itens;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeradorCustomizadoGenerico<T>(_items);
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class EnumeradorCustomizadoGenerico<T> : IEnumerator<T>
        {
            private readonly T[] _minhaColecaoApenasIndexPares;
            private int _indice = -2;

            public EnumeradorCustomizadoGenerico(T[] minhaColecaoApenasIndexPares)
            {
                _minhaColecaoApenasIndexPares = minhaColecaoApenasIndexPares;
            }

            public bool MoveNext()
            {
                _indice += 2;
                return _indice < _minhaColecaoApenasIndexPares.Length;
            }

            public void Reset()
            {
                _indice = -2;
            }

            public T Current => _minhaColecaoApenasIndexPares[_indice];


            // Implementação do Curret não-genérico em caso da utilização do mesmo enumerador em uma coleção customizada não-genérica
            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}
