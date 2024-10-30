using CSharp.Collections.Utils;
using System.Collections;


namespace CSharp.Collections.Collection.Exemplo1
{
    internal class MinhaCollectionCustomizada : System.Collections.ICollection
    {
        private int[] _items;

        public MinhaCollectionCustomizada(int size)
        {
            _items = new int[size];
        }

        // Contabilizar a quantidade de itens que a coleção possui
        public int Count => _items != null ? _items.Length : 0;

        // Informa se a coleção é thread-safe (caso true), se a coleção pode ser acessada
        // por mais de uma thread (false) ou apenas por uma (true)
        public bool IsSynchronized => false;

        // Usada em conjunto com o IsSynchronized, se a coleção for thread-safe (true), é possível fazer o bloqueio (por exemplo, via lock)
        // durante acesso a coleção, isso garante que apenas uma thread acesse ou manipule a coleção por vez
        public object SyncRoot => this;

        // Permite a copia dos objetos de uma coleção para uma array, permitindo passar o index de início
        public void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (array.Length - index < _items.Length)
                throw new ArgumentException("O array não tem espaço suficiente.");

            _items.CopyTo(array, index);

        }

        // Vem da IEnumerable
        public IEnumerator GetEnumerator()
        {
            return new Enumerador<int>(_items);
        }


        public void Adicionar(params int[] numeros)
        {
            int index = 0;

            foreach(var numero in numeros)
            {
                _items[index] = numero;
                index++;
            }
        }
    }
}
