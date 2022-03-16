using System;

namespace Clube_da_Leitura
{
    internal class Program
    {
        static Amigo[] listaAmigos = new Amigo[10];
        static Revista[] listaRevistas = new Revista[10];
        static Emprestimo[] listaEmprestimos = new Emprestimo[10];
        static Caixa[] listaCaixas = new Caixa[10];
              
        static void Main(string[] args)
        {
            
            MenuPrincipal principal = new MenuPrincipal();
            principal.Menu(ref listaAmigos, ref listaRevistas, ref listaEmprestimos, ref listaCaixas);


        }
    }
    
}
