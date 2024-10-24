using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Collections.IEnumerator.Exemplo1
{
    // Classe enumeradora customizada 
    internal class EnumeradorCustomizado<T>
    {
        private List<T> items = new List<T>();

        public EnumeradorCustomizado()
        {
            
        }

        public EnumeradorCustomizado(params T[] numeros)
        {
            items = new List<T>(numeros);
        }

        public void Adicionar(T obj)
        {
            items.Add(obj);
        }

        public void Limpar()
        {
            items = new List<T>();
        }

        public void Remover(T obj)
        {
            items.Remove(obj);
        }

        // Para o funcionamento no foreach, é necessário possui um método publico com nome GetEnumerator() e que retorne um
        // objeto que contenha a implementação dos métodos MoveNext(), Reset() e declaração da propriedade Current
        public Enumerador GetEnumerator()
        {

            return new Enumerador(this);
        }

        // Classe que é retornada pelo método GetEnumerator do enumerador customizado
        public class Enumerador
        {
            private readonly EnumeradorCustomizado<T> _enumeradorCustomizado;
            private int _indice = -1;

            public Enumerador(EnumeradorCustomizado<T> colecao)
            {
                _enumeradorCustomizado = colecao;
            }

            // Obrigatório ter a propriedade declarada para funcionar corretamente no foreach
            public T Current => _enumeradorCustomizado.items[_indice];

            // Obrigatório ter a implementação do método para funcionar corretamente no foreach
            public bool MoveNext()
            {
                _indice++;
                return _indice < _enumeradorCustomizado.items.Count;
            }

            // Obrigatório ter a implementação do método para funcionar corretamente no foreach
            public void Reset()
            {
                _indice = -1;
            }
        }
    }
}
