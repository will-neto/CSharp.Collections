using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Collections.IEnumerator.Exemplo1
{
    // Classe customizada de coleção
    internal class ColecaoCustomizada<T>
    {
        private List<T> items = new List<T>();

        public ColecaoCustomizada()
        {
            
        }

        public ColecaoCustomizada(params T[] numeros)
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
        public EnumeradorCustomizado GetEnumerator()
        {

            return new EnumeradorCustomizado(this);
        }

        // Classe que é retornada pelo método GetEnumerator na coleção customizada
        public class EnumeradorCustomizado
        {
            private readonly ColecaoCustomizada<T> _colecao;
            private int _indice = -1;

            public EnumeradorCustomizado(ColecaoCustomizada<T> colecao)
            {
                _colecao = colecao;
            }

            // Obrigatório ter a propriedade declarada para funcionar corretamente no foreach
            public T Current => _colecao.items[_indice];

            // Obrigatório ter a implementação do método para funcionar corretamente no foreach
            public bool MoveNext()
            {
                _indice++;
                return _indice < _colecao.items.Count;
            }

            // Obrigatório ter a implementação do método para funcionar corretamente no foreach
            public void Reset()
            {
                _indice = -1;
            }
        }
    }
}
