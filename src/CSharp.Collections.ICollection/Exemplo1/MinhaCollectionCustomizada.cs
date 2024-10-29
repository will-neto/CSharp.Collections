using System.Collections;


namespace CSharp.Collections.Collection.Exemplo1
{
    internal class MinhaCollectionCustomizada : ICollection
    {

        // Contabilizar a quantidade de itens que a coleção possui
        public int Count => throw new NotImplementedException();

        // Informa se a coleção é thread-safe (caso true), se a coleção pode ser acessada
        // por mais de uma thread (false) ou apenas por uma (true)
        public bool IsSynchronized => throw new NotImplementedException();

        // Usada em conjunto com o IsSynchronized, se a coleção for thread-safe (true), é possível fazer o bloqueio (por exemplo, via lock)
        // durante acesso a coleção, isso garante que apenas uma thread acesse ou manipule a coleção por vez
        public object SyncRoot => throw new NotImplementedException();

        // Permite a copia dos objetos de uma coleção para uma array, permitindo passar o index de início
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        // Vem da IEnumerable
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
