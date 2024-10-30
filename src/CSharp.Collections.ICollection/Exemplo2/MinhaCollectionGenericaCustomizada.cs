using CSharp.Collections.Collection.Exemplo1;
using CSharp.Collections.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Collections.Collection.Exemplo2
{
    internal class MinhaCollectionGenericaCustomizada<T> : ICollection<T>
    {
        // Campos para controle da entrada de itens
        // Iremos criar uma coleção redimensionavel
        private T[] _items; // Itens
        private int _count; // Quantidade de Itens
        private int InitialCapacity = 4;
        private int Capacity => _items.Length; // Capacidade, que definirá o redimensionamento


        public MinhaCollectionGenericaCustomizada()
        {
            Clear();
        }

        private void Resize()
        {
            int newCapacity = _items.Length * 2;
            T[] newArray = new T[newCapacity];

            // Copia os itens do array antigo para o novo array com maior capacidade
            for (int i = 0; i < _items.Length; i++)
            {
                newArray[i] = _items[i];
            }

            // Substitui o array interno pelo novo array
            _items = newArray;
        }

        // Quantidade de itens na lista
        public int Count => _count;

        // Informa se a lista é somente-leitura
        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }

            _items[_count] = item;
            _count++;
        }

        public void Clear()
        {
            _items = new T[InitialCapacity];
            _count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_items[i], item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_items, 0, array, arrayIndex, _count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerador<T>(_items);
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_items[i], item))
                {
                    // Move os itens subsequentes para preencher o espaço
                    for (int j = i; j < _count - 1; j++)
                    {
                        _items[j] = _items[j + 1];
                    }

                    _items[--_count] = default; // Opcional: limpa o último item

                    return true; // Retorna verdadeiro se o item foi removido
                }
            }
            return false; // Retorna falso se o item não foi encontrado
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
