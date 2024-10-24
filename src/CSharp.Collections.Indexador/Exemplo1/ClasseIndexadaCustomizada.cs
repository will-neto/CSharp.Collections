using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Collections.Indexador.Exemplo1
{
    // É possível criar classes customizadas com indexação, que nos permite utilizá-las em loops "for"
    internal class ClasseIndexadaCustomizada<T>
    {
        // Inicializa o array interno com o tamanho informado no construtor
        public ClasseIndexadaCustomizada(int size)
        {
            _items = new T[size];
            _count = 0;
        }

        private T[] _items;

        private int _count;

        public int Tamanho => _items?.Length ?? 0;

        // Para isso, é necessário declarar um método de indexação
        // Isso nos permite acessar uma classe como se fosse um array
        public T? this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                {
                    return default;
                }

                return _items[index];
            }
        }


        public void Adicionar(T item)
        {
            if (_count == _items.Length)
            {
                throw new Exception("Lista já está cheia.");
            }

            _items[_count++] = item;
        }


    }
}
