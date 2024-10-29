using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Collections.Utils
{
    public class Enumerador<T> : IEnumerator<T>
    {
        private readonly T[] _items;
        private int _indice = -1;

        public Enumerador(T[] items)
        {
            _items = items;
        }

        public bool MoveNext()
        {
            _indice++;
            return _indice < _items.Length;
        }

        public void Reset()
        {
            _indice = -1;
        }

        public T Current => _items[_indice];


        // Implementação do Curret não-genérico em caso da utilização do mesmo enumerador em uma coleção customizada não-genérica
        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}
