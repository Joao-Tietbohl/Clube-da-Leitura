using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube_da_Leitura
{
    
    internal class Caixa
    {
        public string cor;
        public string etiqueta;
        public int numero;
        public int id;

        static int contadorCaixas = 0;

        public Caixa()
        {
        }

        public Caixa(string cor, string etiqueta, int numero)
        {
            this.cor = cor;
            this.etiqueta = etiqueta;
            this.numero = numero;
        }

        public bool MenuCaixas(ref Caixa[] listaCaixas)
        {
            int opcao = 0;
            while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Cadastrar Caixa");
                Console.WriteLine("2 - Visualizar Caixas");
                Console.WriteLine("3 - Excluir Caixa");
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
                    CadastrarCaixa(ref listaCaixas);
                    break;
                case 2:
                    VisualizarCaixas(ref listaCaixas);
                    break;
                case 3:
                    ExcluirCaixa(ref listaCaixas);
                    break;
            }
            return true;
        }

        public void CadastrarCaixa(ref Caixa[] listaCaixas)
        {
            Caixa novaCaixa = new Caixa();

            Console.WriteLine();
            Console.WriteLine("Digite a cor da caixa: ");
            novaCaixa.cor = Console.ReadLine();
            Console.WriteLine("Digite a etiqueta da caixa: ");
            novaCaixa.etiqueta = Console.ReadLine();
            Console.WriteLine("Digite o número da caixa: ");
            int numeroCaixa = Int32.Parse(Console.ReadLine());

            for(int i = 0; i < contadorCaixas; i++)
            {
                while(numeroCaixa == listaCaixas[i].numero)
                {
                    Console.WriteLine("Número já cadastrado. Digite outro.");
                    numeroCaixa = Int32.Parse(Console.ReadLine());
                }
            }
            novaCaixa.numero = numeroCaixa;
            

            novaCaixa.id = (contadorCaixas + 1);

            listaCaixas[contadorCaixas] = novaCaixa;
            contadorCaixas++;
        }

        public void VisualizarCaixas(ref Caixa[] listaCaixas)
        {
            foreach(Caixa item in listaCaixas)
            {
                if (item != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("ID: " + item.id);
                    Console.WriteLine("Cor da caixa: " + item.cor);
                    Console.WriteLine("Etiqueta: " + item.etiqueta);
                    Console.WriteLine("Numero: " + item.numero);
                }
            }
        }

        public void ExcluirCaixa(ref Caixa[] listaCaixas)
        {
            Console.WriteLine();
            Console.WriteLine("Digite o ID da caixa a ser excluída: ");
            int IDparaExcluir = Int32.Parse(Console.ReadLine());
            IDparaExcluir--;

            Caixa[] novaArrayListaCaixas = new Caixa[10];
            int cont = 0;
            for (int i = 0; i < listaCaixas.Length; i++)
            {
                if (i != IDparaExcluir)
                {
                    novaArrayListaCaixas[cont] = listaCaixas[i];

                    if (i >= IDparaExcluir && novaArrayListaCaixas[cont] != null)
                    {
                        novaArrayListaCaixas[cont].id = novaArrayListaCaixas[cont].id - 1;
                    }
                    cont++;
                }
            }

            for (int i = 0; i < novaArrayListaCaixas.Length; i++)
            {
                listaCaixas[i] = novaArrayListaCaixas[i];
            }
        }
    }
}
