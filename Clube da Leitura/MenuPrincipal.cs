using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube_da_Leitura
{
    
    internal class MenuPrincipal
    {
        int opcao;

        public void Menu(ref Amigo[] listaAmigos, ref Revista[] listaRevistas, ref Emprestimo[] listaEmprestimos, ref Caixa[] listaCaixas)
        {
            while(opcao != 5){

                do
                {

                    Console.WriteLine();
                    Console.WriteLine("1 - Menu Amigos");
                    Console.WriteLine("2 - Menu Revistas");
                    Console.WriteLine("3 - Menu Caixas");
                    Console.WriteLine("4 - Menu de empréstimos");
                    Console.WriteLine("5 - Sair");

                    opcao = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5);

                    switch (opcao)
                {
                    case 1:
                        Amigo chamaMenuAmigos = new Amigo();
                        chamaMenuAmigos.MenuAmigos(ref listaAmigos);
                        break;
                    case 2:
                        Revista chamaMenuRevistas = new Revista();
                        chamaMenuRevistas.MenuRevistas(ref listaRevistas, ref listaCaixas);
                        break;
                    case 3:
                        Caixa chamaMenuCaixas = new Caixa();
                        chamaMenuCaixas.MenuCaixas(ref listaCaixas);
                        break;
                    case 4:
                        Emprestimo chamaMenuEmprestimo = new Emprestimo();
                        chamaMenuEmprestimo.MenuEmprestimos(ref listaEmprestimos, ref listaAmigos, ref listaRevistas);
                        break;
                }
            }
        }
    }
}
