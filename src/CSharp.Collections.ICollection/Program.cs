using System.Collections;

namespace CSharp.Collections.Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICollection();
        }

        private static void ICollection()
        {
            /*
                - A "ICollection" é uma interface não-genérica que implementa a interface "IEnumerable";
                - Permite qualquer tipo de objeto (assim como a IEnumerable); 
                - Criada para ser uma abstração para uso por outras interfaces (IList, IDictionary) ou classes concretas
                    (Queue, Stack, BitArray) possam estender suas funcionalidades;
             */

        }
    }
}
