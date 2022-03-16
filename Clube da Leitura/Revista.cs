using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube_da_Leitura
{
    internal class Revista
    {
        public string colecao;
        public string numeroEdicao;
        public string anoRevista;
        public Caixa caixa;
        public int id;

        static int contadorRevistas = 0;

        public Revista(string colecao, string numeroEdicao, string anoRevista, Caixa caixa)
        {
            this.colecao = colecao;
            this.numeroEdicao = numeroEdicao;
            this.anoRevista = anoRevista;
            this.caixa = caixa;
        }

        public Revista()
        {
        }

        public bool MenuRevistas(ref Revista[] listaRevistas, ref Caixa[] listaCaixas)
        {
            int opcao = 0;
            while (opcao != 1 && opcao != 2 && opcao != 3 && opcao!= 4)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Cadastrar Revista");
                Console.WriteLine("2 - Visualizar Revista");
                Console.WriteLine("3 - Excluir Revista");
                Console.WriteLine("4 - Voltar");
                opcao = Int32.Parse(Console.ReadLine());
                Console.Clear();

            }

            if (opcao == 4)
            {
                return true;
            }

            switch (opcao)
            {
                case 1:
                    CadastrarRevista(ref listaRevistas,ref listaCaixas);
                    break;
                case 2:
                    VisualizarRevistas(ref listaRevistas);
                    break;
                case 3:
                    ExcluirRevista(ref listaRevistas);
                    break;

            }
            return true;
        }


        public bool CadastrarRevista(ref Revista[] listaRevistas, ref Caixa[] listaCaixas)
        {
            Caixa chamaContador = new Caixa();
            Revista novaRevista = new Revista();

            Console.WriteLine();
            Console.WriteLine("Digite a coleção da revista: ");
            novaRevista.colecao = Console.ReadLine();
            Console.WriteLine("Digite o numero de edição da revista: ");
            novaRevista.numeroEdicao = Console.ReadLine();
            Console.WriteLine("Digite o ano da Revista: ");
            novaRevista.anoRevista = Console.ReadLine();
            Console.WriteLine("Digite o número da caixa: ");
            int numeroCaixa = Int32.Parse(Console.ReadLine());

            //Verifica se caixa é válida
            for (int i = 0; i < listaCaixas.Length; i++)
            {
                if(listaCaixas[i] == null){
                    Console.WriteLine("Caixa não cadastrada");
                    return true;
                }
                if (numeroCaixa == listaCaixas[i].numero)
                {
                    novaRevista.caixa = listaCaixas[i];
                    break;
                }                
            }
            

            novaRevista.id = (contadorRevistas + 1);

            listaRevistas[contadorRevistas] = novaRevista;
            contadorRevistas++;
            return true;
        }

        public void VisualizarRevistas(ref Revista[] listaRevistas)
        {
            foreach (Revista item in listaRevistas)
            {
                if (item != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("ID: " + item.id);
                    Console.WriteLine("Coleção: " + item.colecao);
                    Console.WriteLine("Numero da Edição: " + item.numeroEdicao);
                    Console.WriteLine("Ano da Revista: " + item.anoRevista);
                    Console.WriteLine("Caixa nr: " + item.caixa.numero);
                }
            }

        }

        public void ExcluirRevista(ref Revista[] listaRevistas)
        {
            Console.WriteLine();
            Console.WriteLine("Digite o ID da Revista a ser excluída: ");
            int IDparaExcluir = Int32.Parse(Console.ReadLine());
            IDparaExcluir--;

            Revista[] novaArrayListaRevistas = new Revista[10];
            int cont = 0;
            for (int i = 0; i < listaRevistas.Length; i++)
            {
                if (i != IDparaExcluir)
                {
                    novaArrayListaRevistas[cont] = listaRevistas[i];

                    if (i >= IDparaExcluir && novaArrayListaRevistas[cont] != null)
                    {
                        novaArrayListaRevistas[cont].id = novaArrayListaRevistas[cont].id - 1;
                    }
                    cont++;
                }
            }

            for (int i = 0; i < novaArrayListaRevistas.Length; i++)
            {
                listaRevistas[i] = novaArrayListaRevistas[i];
            }
        }
    }
}
