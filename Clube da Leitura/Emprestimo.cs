using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube_da_Leitura
{
    class Emprestimo
    {
        public Amigo amigoQuePegouEmprestado;
        public Revista revistaEmprestada;
        public DateTime dataDoEmprestimo;
        public DateTime dataDeDevolucao;
        
        public int id;
       
        static int contadorEmprestimos = 0;

        public bool MenuEmprestimos(ref Emprestimo[] listaEmprestimos, ref Amigo[] listaAmigos, ref Revista[] listaRevistas)
        {
            int opcao = 0;
            while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Cadastrar Emprestimo");
                Console.WriteLine("2 - Visualizar Emprestimos");
                Console.WriteLine("3 - Excluir Emprestimo");
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
                    CadastrarEmprestimo(ref listaEmprestimos,ref listaAmigos,ref listaRevistas);
                    break;
                case 2:
                    VisualizarEmprestimos(ref listaEmprestimos);
                    break;
                case 3:
                    ExcluirEmprestimo(ref listaEmprestimos);
                    break;

            }
            return true;
        }


        public bool CadastrarEmprestimo(ref Emprestimo[] listaEmprestimos,ref Amigo[] listaAmigos,ref Revista[] listaRevistas)
        {
            Emprestimo novoEmprestimo = new Emprestimo();

            novoEmprestimo.id = (contadorEmprestimos + 1);
            //Parte amigo
            Console.WriteLine();
            Console.WriteLine("Digite ID do amigo que vai pegar a revista emprestada: ");
            int idAmigo = Int32.Parse(Console.ReadLine());
            idAmigo--;
            
            if(listaAmigos[idAmigo] == null) {
                Console.WriteLine("Amigo não está cadastrado");
                return true;
            }

            for (int i = 0; i < contadorEmprestimos; i++) {
                if (listaAmigos[idAmigo] == listaEmprestimos[i].amigoQuePegouEmprestado && listaEmprestimos[i].dataDeDevolucao > DateTime.Now)
                {
                    Console.WriteLine("Amigo tem emprestimo em aberto");
                    return true;
                }
            }
            
           novoEmprestimo.amigoQuePegouEmprestado = listaAmigos[idAmigo];

            //Parte Revista

            Console.WriteLine();
            Console.WriteLine("Digite o ID da revista que vai ser emprestada: ");
            int idRevista = Int32.Parse(Console.ReadLine());
            idRevista--;

            if (listaRevistas[idRevista] == null)
            {
                Console.WriteLine("Revista não está cadastrada");
                return true;
            }

            for (int i = 0; i < contadorEmprestimos; i++)
            {
                if (listaRevistas[idRevista] == listaEmprestimos[i].revistaEmprestada && listaEmprestimos[i].dataDeDevolucao > DateTime.Now)
                {
                    Console.WriteLine("Revista esta atrelada a emprestimo em aberto");
                    return true;
                }
            }

                novoEmprestimo.revistaEmprestada = listaRevistas[idRevista];

            //Resto

            Console.WriteLine();
            Console.WriteLine("Digite a data do emprestimo: ");
            string strDataAbertura = Console.ReadLine();
            DateTime dataAbertura = Convert.ToDateTime(strDataAbertura);
            novoEmprestimo.dataDoEmprestimo = dataAbertura;

            Console.WriteLine();
            Console.WriteLine("Digite a data de devolução: ");
            string strDataDevolucao = Console.ReadLine();
            DateTime dataDevolucao = Convert.ToDateTime(strDataDevolucao);
            novoEmprestimo.dataDeDevolucao = dataDevolucao;

            listaEmprestimos[contadorEmprestimos] = novoEmprestimo;

            contadorEmprestimos++;


            return true;
        }

        public void VisualizarEmprestimos(ref Emprestimo[] listaEmprestimos)
        {
            int opcao = 0;
            while (opcao != 1 && opcao != 2 && opcao != 3)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Visualizar todos os emprestimos");
                Console.WriteLine("2 - Visualizar emprestimos do mês");
                Console.WriteLine("3 - Visualizar emprestimos em aberto");
                opcao = Int32.Parse(Console.ReadLine());
            }

            switch (opcao)
            {
                case 1:

                    foreach (Emprestimo item in listaEmprestimos)
                    {
                        if (item != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("ID: " + item.id);
                            Console.WriteLine("Amigo que pegou emprestado: " + item.amigoQuePegouEmprestado.nome);
                            Console.WriteLine("Coleção da revista que foi emprestada: " + item.revistaEmprestada.colecao);
                            Console.WriteLine("Numero da edição da revista: " + item.revistaEmprestada.numeroEdicao);
                            Console.WriteLine("Data do emprestimo: " + item.dataDoEmprestimo.ToShortDateString());
                            Console.WriteLine("Data de devolucao: " + item.dataDeDevolucao.ToShortDateString());

                        }
                    }
                    break;
                case 2:

                    Console.WriteLine();
                    Console.WriteLine("Emprestimos do mes");
                    foreach (Emprestimo item in listaEmprestimos)
                    {
                        if (item != null)
                        {
                            if (item.dataDoEmprestimo <= DateTime.Now && item.dataDoEmprestimo >= DateTime.Now.AddDays(-30)) {
                                Console.WriteLine();
                                Console.WriteLine("ID: " + item.id);
                                Console.WriteLine("Amigo que pegou emprestado: " + item.amigoQuePegouEmprestado.nome);
                                Console.WriteLine("Coleção da revista que foi emprestada: " + item.revistaEmprestada.colecao);
                                Console.WriteLine("Numero da edição da revista: " + item.revistaEmprestada.numeroEdicao);
                                Console.WriteLine("Data do emprestimo: " + item.dataDoEmprestimo.ToShortDateString());
                                Console.WriteLine("Data de devolucao: " + item.dataDeDevolucao.ToShortDateString());
                            }
                        }
                    }
                    break;
                case 3:

                    Console.WriteLine();
                    Console.WriteLine("Emprestimos em Aberto");
                    foreach (Emprestimo item in listaEmprestimos)
                    {
                        if (item != null)
                        {
                            if (item.dataDeDevolucao > DateTime.Now)
                            {
                                Console.WriteLine();
                                Console.WriteLine("ID: " + item.id);
                                Console.WriteLine("Amigo que pegou emprestado: " + item.amigoQuePegouEmprestado.nome);
                                Console.WriteLine("Coleção da revista que foi emprestada: " + item.revistaEmprestada.colecao);
                                Console.WriteLine("Numero da edição da revista: " + item.revistaEmprestada.numeroEdicao);
                                Console.WriteLine("Data do emprestimo: " + item.dataDoEmprestimo.ToShortDateString());
                                Console.WriteLine("Data de devolucao: " + item.dataDeDevolucao.ToShortDateString());
                            }
                        }
                    }
                    break;

            }
        }

        public void ExcluirEmprestimo(ref Emprestimo[] listaEmprestimos)
        {
            Console.WriteLine();
            Console.WriteLine("Digite o ID do Emprestimo a ser excluído: ");
            int IDparaExcluir = Int32.Parse(Console.ReadLine());
            IDparaExcluir--;

            Emprestimo[] novaArrayListaEmprestimos = new Emprestimo[10];
            int cont = 0;
            for (int i = 0; i < listaEmprestimos.Length; i++)
            {
                if (i != IDparaExcluir)
                {
                    novaArrayListaEmprestimos[cont] = listaEmprestimos[i];

                    if (i >= IDparaExcluir && novaArrayListaEmprestimos[cont] != null)
                    {
                        novaArrayListaEmprestimos[cont].id = novaArrayListaEmprestimos[cont].id - 1;
                    }
                    cont++;
                }
            }

            for (int i = 0; i < novaArrayListaEmprestimos.Length; i++)
            {
                listaEmprestimos[i] = novaArrayListaEmprestimos[i];
            }
        }
    }
}
