using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube_da_Leitura
{
    internal class Amigo
    {
        public string nome;
        public string nomeDoResponsavel;
        public string telefone;
        public string endereco;

        public int id;

        static int contadorAmigos = 0;

        public Amigo()
        {
        }

        public Amigo(string nome, string nomeDoResponsavel, string telefone, string endereco)
        {
            this.nome = nome;
            this.nomeDoResponsavel = nomeDoResponsavel;
            this.telefone = telefone;
            this.endereco = endereco;
        }

        public bool MenuAmigos(ref Amigo[] listaAmigos)
        {
            int opcao = 0;
            while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Cadastrar Amigo");
                Console.WriteLine("2 - Visualizar Amigos");
                Console.WriteLine("3 - Excluir Amigo");
                Console.WriteLine("4 - Voltar");
                opcao = Int32.Parse(Console.ReadLine());
                Console.Clear();

            }

            if(opcao == 4)
            {
                return true;
            }
            switch (opcao)
            {
                case 1:
                    CadastrarAmigo(ref listaAmigos);
                    break;
                case 2:
                    VisualizarAmigos(ref listaAmigos);
                    break;
                case 3:
                    ExcluirAmigo(ref listaAmigos);
                    break;
            }
            return true;
        }
        public void CadastrarAmigo(ref Amigo[] listaAmigos)
        {
            Amigo novoAmigo = new Amigo();

            Console.WriteLine();
            Console.WriteLine("Digite o nome do amigo: ");
            novoAmigo.nome = Console.ReadLine();
            Console.WriteLine("Digite o nome do responsável: ");
            novoAmigo.nomeDoResponsavel = Console.ReadLine();
            Console.WriteLine("Digite telefone: ");
            novoAmigo.telefone = Console.ReadLine();
            Console.WriteLine("Digite o endereço: ");
            novoAmigo.endereco = Console.ReadLine();

            novoAmigo.id = (contadorAmigos + 1);

            listaAmigos[contadorAmigos] = novoAmigo;
            contadorAmigos++;
        }

        public void VisualizarAmigos(ref Amigo[] listaAmigos)
        {
            foreach (Amigo item in listaAmigos)
            {
                if (item != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("ID: " + item.id);
                    Console.WriteLine("Nome: " + item.nome);
                    Console.WriteLine("Nome do Responsável: " + item.nomeDoResponsavel);
                    Console.WriteLine("Telefone: " + item.telefone);
                    Console.WriteLine("Endereço: " + item.endereco);
                }
            }
        }

        public void ExcluirAmigo(ref Amigo[] listaAmigos)
        {
            Console.WriteLine();
            Console.WriteLine("Digite o ID do amigo a ser excluído: ");
            int IDparaExcluir = Int32.Parse(Console.ReadLine());
            IDparaExcluir--;

            Amigo[] novaArrayListaAmigos = new Amigo[10];
            int cont = 0;
            for (int i = 0; i < listaAmigos.Length; i++)
            {               
                if (i != IDparaExcluir)
                {
                    novaArrayListaAmigos[cont] = listaAmigos[i];
                    
                    if (i >= IDparaExcluir && novaArrayListaAmigos[cont] != null)
                    {
                        novaArrayListaAmigos[cont].id = novaArrayListaAmigos[cont].id - 1;
                    }
                    cont++;
                }               
            }

            for(int i = 0; i < novaArrayListaAmigos.Length; i++)
            {
                listaAmigos[i] = novaArrayListaAmigos[i];
            }

        }
    }
}
