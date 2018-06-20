using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_da_Velha
{

  class Program
  {
    public class Posicao
    {
      int linha, coluna;

      public Posicao(int linha, int coluna)
      {
        this.linha = linha;
        this.coluna = coluna;
      }

      public void SetLinha(int linha)
      {
        this.linha = linha;
      }
      public void SetColuna(int coluna)
      {
        this.coluna = coluna;
      }
      public int getLinha()
      {
        return linha;
      }
      public int getColuna()
      {
        return coluna;
      }


    }

    public static char[,] Tabuleiro { get; private set; }
    static void Main(string[] args)
    {

      string opcao, opcao2, opcao3, opcao4, opcao5;

      do
      {

        Console.WriteLine("Bem vindo - Jogo da Velha\n");
        Console.WriteLine("1 - Jogar");
        Console.WriteLine("0 - Sair");
        Console.Write("\nDigite uma das opções: ");
        opcao = Console.ReadLine();
        Console.Clear();

        switch (opcao)
        {
          case "1": //jogar
            do
            {
              Console.WriteLine("Bem vindo - Jogo da Velha\n");
              Console.WriteLine("1 - Dois jogadores");
              Console.WriteLine("2 - Um jogador");
              Console.WriteLine("0 - Voltar");
              Console.Write("\nDigite uma das opções: ");
              opcao2 = Console.ReadLine();

              Console.Clear();

              switch (opcao2)
              {
                case "1"://um jogador
                  Jogar();
                  Console.Clear();
                  break;
                case "2"://dois jogadores
                  do
                  {
                    Console.WriteLine("Bem vindo - Jogo da Velha\n");
                    Console.WriteLine("1 - Facil");
                    Console.WriteLine("2 - Médio");
                    Console.WriteLine("0 - Voltar");
                    Console.Write("\nDigite uma das opções: ");
                    opcao3 = Console.ReadLine();

                    Console.Clear();

                    switch (opcao3)
                    {
                      case "1":
                        do
                        {
                          Console.WriteLine("Bem vindo - Jogo da Velha - Fácil\n");
                          Console.WriteLine("1 - Comecar jogando");
                          Console.WriteLine("2 - Adversário comeca");
                          Console.WriteLine("0 - Voltar");
                          Console.Write("\nDigite uma das opções: ");
                          opcao4 = Console.ReadLine();

                          Console.Clear();

                          switch (opcao4)
                          {
                            case "1":
                              Jogar2Facil();
                              break;
                            case "2":
                              Jogar2FacilO();
                              break;
                            default:
                              break;
                          }

                        } while (opcao4 != "0");
                        break;
                      case "2":
                        do
                        {
                          Console.WriteLine("Bem vindo - Jogo da Velha - Dificil\n");
                          Console.WriteLine("1 - Comecar jogando");
                          Console.WriteLine("2 - Adversário comeca");
                          Console.WriteLine("0 - Voltar");
                          Console.Write("\nDigite uma das opções: ");
                          opcao5 = Console.ReadLine();

                          Console.Clear();

                          switch (opcao5)
                          {
                            case "1":
                              Jogar2Medio();
                              break;
                            case "2":
                              Jogar2MedioO();
                              break;
                            default:
                              break;
                          }

                        } while (opcao5 != "0");
                        break;
                      default:
                        break;
                    }

                  } while (opcao3 != "0");
                  break;
                default:
                  break;
              }
            } while (opcao2 != "0");

            break;
          default:
            break;
        }
      } while (opcao != "0");
    }
    public static void Jogar()
    {
      CriaTab();
      ExibeTab();
      while (Vitoria() == false)
      {
        Jogador1();

        if (Vitoria() == true)
        {
          return;
        }

        Jogador2();
      }

    }

    public static void Jogar2Facil()
    {
      CriaTab();
      ExibeTab();
      while (Vitoria() == false)
      {
        Jogador1();

        if (Vitoria() == true)
        {
          return;
        }
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
        Jogador2Facil();
      }

    }
    public static void Jogar2FacilO()
    {
      CriaTab();
      ExibeTab();
      while (Vitoria() == false)
      {
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
        Jogador2Facil();

        if (Vitoria() == true)
        {
          return;
        }
        Jogador1();
      }

    }

    public static void Jogar2Medio()
    {
      CriaTab();
      ExibeTab();
      while (Vitoria() == false)
      {
        Jogador1();

        if (Vitoria() == true)
        {
          return;
        }
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
        Jogador2Medio();
      }
    }
    public static void Jogar2MedioO()
    {
      CriaTab();
      ExibeTab();
      while (Vitoria() == false)
      {
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
        Jogador2Medio();

        if (Vitoria() == true)
        {
          return;
        }
        Jogador1();
      }

    }

    public static void CriaTab()
    {
      Tabuleiro = new char[3, 3];
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          Tabuleiro[i, j] = '-';
        }
      }
    }

    public static void ExibeTab()
    {
      Console.WriteLine("   1   2   3");
      for (int i = 0; i < 3; i++)
      {
        if (i == 1 | i == 2)
        {
          Console.WriteLine("  ____________");
        }

        Console.Write(i + 1 + " ");
        for (int j = 0; j < 3; j++)
        {

          if (j != 2)
          {
            Console.Write(" " + Tabuleiro[i, j] + " ");
            Console.Write("|");
          }
          else
          {
            Console.Write(" " + Tabuleiro[i, j] + " ");
          }
        }
        Console.Write("\n");
      }
      Console.Write("\n");
    }

    public static int EscolheLin()
    {
      int num;
      Console.Write("Escolha uma posição de acordo com a linha:");
      num = int.Parse(Console.ReadLine());
      while (num != 1 & num != 2 & num != 3)
      {
        Console.WriteLine("Esta posição não esxite, digite novamente");
        Console.ReadKey();
        Console.Clear();
        ExibeTab();
        Console.Write("Escolha uma posição de acordo com a linha:");
        num = int.Parse(Console.ReadLine());
      }

      return num;
    }

    public static int EscolheCol()
    {
      int num;
      Console.Write("Escolha uma posição de acordo com a Coluna:");
      num = int.Parse(Console.ReadLine());
      while (num != 1 & num != 2 & num != 3)
      {
        Console.WriteLine("Esta posição não esxite, digite novamente");
        Console.ReadKey();
        Console.Clear();
        ExibeTab();
        Console.Write("Escolha uma posição de acordo com a Coluna:");
        num = int.Parse(Console.ReadLine());
      }

      return num;
    }

    public static void Jogador1()
    {
      int lin, col;

      Console.Clear();
      Console.WriteLine("Jogador -X- joga!\n");
      ExibeTab();

      lin = EscolheLin() - 1;
      col = EscolheCol() - 1;

      if (Tabuleiro[lin, col] == 'X' | Tabuleiro[lin, col] == 'O')
      {
        Console.WriteLine("Posição ja preenchida escolha outra!");
        Console.ReadKey();
        Jogador1();
      }
      else
      {
        Tabuleiro[lin, col] = 'X';
        Console.Clear();
        Console.WriteLine("Jogador -O- joga!\n"); ;
        ExibeTab();
      }
    }

    public static void Jogador2()
    {
      int lin, col;

      Console.Clear();
      Console.WriteLine("Jogador -O- joga!\n");
      ExibeTab();
      lin = EscolheLin() - 1;
      col = EscolheCol() - 1;

      if (Tabuleiro[lin, col] == 'X' | Tabuleiro[lin, col] == 'O')
      {
        Console.WriteLine("Posição ja preenchida escolha outra!");
        Console.ReadKey();
        Jogador2();
      }
      else
      {
        Tabuleiro[lin, col] = 'O';
        Console.Clear();
        ExibeTab();
      }

    }

    public static Boolean Vitoria()
    {

      int count = 0;

      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (Tabuleiro[i, j] == 'X' | Tabuleiro[i, j] == 'O')
          {
            count++;
          }
        }
      }

      if (Tabuleiro[0, 0] == 'X' & Tabuleiro[0, 1] == 'X' & Tabuleiro[0, 2] == 'X' |
              Tabuleiro[1, 0] == 'X' & Tabuleiro[1, 1] == 'X' & Tabuleiro[1, 2] == 'X' |
              Tabuleiro[2, 0] == 'X' & Tabuleiro[2, 1] == 'X' & Tabuleiro[2, 2] == 'X' |
              Tabuleiro[0, 0] == 'X' & Tabuleiro[1, 0] == 'X' & Tabuleiro[2, 0] == 'X' |
              Tabuleiro[0, 1] == 'X' & Tabuleiro[1, 1] == 'X' & Tabuleiro[2, 1] == 'X' |
              Tabuleiro[0, 2] == 'X' & Tabuleiro[1, 2] == 'X' & Tabuleiro[2, 2] == 'X' |
              Tabuleiro[0, 0] == 'X' & Tabuleiro[1, 1] == 'X' & Tabuleiro[2, 2] == 'X' |
              Tabuleiro[0, 2] == 'X' & Tabuleiro[1, 1] == 'X' & Tabuleiro[2, 0] == 'X')
      {
        Console.Clear();
        Console.WriteLine("O jogador -X- ganhou!!!\n");
        ExibeTab();
        Console.WriteLine("***************");
        Console.ReadKey();
        Console.Clear();

        return true;
      }
      else if (Tabuleiro[0, 0] == 'O' & Tabuleiro[0, 1] == 'O' & Tabuleiro[0, 2] == 'O' |
              Tabuleiro[1, 0] == 'O' & Tabuleiro[1, 1] == 'O' & Tabuleiro[1, 2] == 'O' |
              Tabuleiro[2, 0] == 'O' & Tabuleiro[2, 1] == 'O' & Tabuleiro[2, 2] == 'O' |
              Tabuleiro[0, 0] == 'O' & Tabuleiro[1, 0] == 'O' & Tabuleiro[2, 0] == 'O' |
              Tabuleiro[0, 1] == 'O' & Tabuleiro[1, 1] == 'O' & Tabuleiro[2, 1] == 'O' |
              Tabuleiro[0, 2] == 'O' & Tabuleiro[1, 2] == 'O' & Tabuleiro[2, 2] == 'O' |
              Tabuleiro[0, 0] == 'O' & Tabuleiro[1, 1] == 'O' & Tabuleiro[2, 2] == 'O' |
              Tabuleiro[0, 2] == 'O' & Tabuleiro[1, 1] == 'O' & Tabuleiro[2, 0] == 'O')
      {
        Console.Clear();
        Console.WriteLine("O jogador -O- ganhou!!!\n");
        ExibeTab();
        Console.WriteLine("***************");
        Console.ReadKey();
        Console.Clear();

        return true;
      }
      else if (count > 8)
      {
        Console.Clear();
        Console.WriteLine("Empate!!!\n");
        ExibeTab();
        Console.WriteLine("***************");
        Console.ReadKey();
        Console.Clear();
        return true;
      }
      else
      {
        return false;
      }


    }

    public static void Jogador2Facil()
    {
      int lin, col;

      Console.Clear();
      ExibeTab();

      lin = RandomPosicao().getLinha();
      col = RandomPosicao().getColuna();

      if (Tabuleiro[lin, col] == 'X' | Tabuleiro[lin, col] == 'O')
      {
        //Console.WriteLine("Posição ja preenchida escolha outra!");
        //Console.ReadKey();
        Jogador2Facil();
      }
      else
      {
        Tabuleiro[lin, col] = 'O';
        Console.Clear();
        ExibeTab();
      }

    }

    public static void Jogador2Medio()
    {
      int casaVazia = 0, casaPreenchida = 0, quantidadeX = 0, quantidadeO = 0;
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (Tabuleiro[i, j] == '-')
            casaVazia++;
          else
            casaPreenchida++;
        }
      }

      if (casaVazia == 8 & Tabuleiro[1, 1] == '-' | casaVazia == 9 & Tabuleiro[1, 1] == '-')
      {
        Tabuleiro[1, 1] = 'O';
        return;
      }

      /******************************/

      //escolhe posição na linha quando ja tem duas peças
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (Tabuleiro[i, j] == 'O')
            quantidadeO++;

        }

        if (quantidadeO == 2)
        {
          for (int j = 0; j < 3; j++)
          {
            if (Tabuleiro[i, j] == '-')
            {
              Tabuleiro[i, j] = 'O';
              return;
            }
          }
        }
        quantidadeO = 0;
      }

      quantidadeO = 0;
      //escolhe posição na coluna quando ja tem duas peças
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (Tabuleiro[j, i] == 'O')
            quantidadeO++;

        }

        if (quantidadeO == 2)
        {
          for (int j = 0; j < 3; j++)
          {
            if (Tabuleiro[j, i] == '-')
            {
              Tabuleiro[j, i] = 'O';
              return;
            }
          }
        }
        quantidadeO = 0;
      }

      /******************************/


      //escolhe posição na primeira diagonal O
      quantidadeO = 0;
      for (int i = 0; i < 1; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (Tabuleiro[j, j] == 'O')
            quantidadeO++;

        }

        if (quantidadeO == 2)
        {
          for (int j = 0; j < 3; j++)
          {
            if (Tabuleiro[j, j] == '-')
            {
              Tabuleiro[j, j] = 'O';
              return;
            }
          }
        }
        quantidadeO = 0;
      }

      //escolhe posição na segunda diagonal O
      for (int i = 0; i < 1; i++)
      {
        int aux = 0;
        for (int j = 2; j >= 0; j--)
        {
          if (Tabuleiro[aux, j] == 'O')
            quantidadeO++;
          aux++;
        }

        aux = 0;

        if (quantidadeO == 2)
        {
          for (int j = 2; j >= 0; j--)
          {
            if (Tabuleiro[aux, j] == '-')
            {
              Tabuleiro[aux, j] = 'O';
              return;
            }
            aux++;
          }
        }
        quantidadeO = 0;
      }

      /******************************/


      //escolhe posição na primeira diagonal X
      quantidadeO = 0;
      //escolhe posição na coluna quando ja tem duas peças
      for (int i = 0; i < 1; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (Tabuleiro[j, j] == 'X')
            quantidadeO++;
        }

        if (quantidadeO == 2)
        {
          for (int j = 0; j < 3; j++)
          {
            if (Tabuleiro[j, j] == '-')
            {
              Tabuleiro[j, j] = 'O';
              return;
            }
          }
        }

        quantidadeO = 0;
      }

      //escolhe posição na segunda diagonal X
      for (int i = 0; i < 1; i++)
      {
        int aux = 0;
        for (int j = 2; j >= 0; j--)
        {
          if (Tabuleiro[aux, j] == 'X')
            quantidadeO++;
          aux++;
        }

        aux = 0;

        if (quantidadeO == 2)
        {
          for (int j = 2; j >= 0; j--)
          {
            if (Tabuleiro[aux, j] == '-')
            {
              Tabuleiro[aux, j] = 'O';
              return;
            }
            aux++;
          }
        }
        quantidadeO = 0;
      }



      /******************************/


      //escolhe posição na linha
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (Tabuleiro[i, j] == 'X')
            quantidadeX++;

        }

        if (quantidadeX == 2)
        {
          for (int j = 0; j < 3; j++)
          {
            if (Tabuleiro[i, j] == '-')
            {
              Tabuleiro[i, j] = 'O';
              return;
            }
          }
        }
        quantidadeX = 0;
      }

      quantidadeX = 0;
      //escolhe posição na Coluna
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (Tabuleiro[j, i] == 'X')
            quantidadeX++;

        }

        if (quantidadeX == 2)
        {
          for (int j = 0; j < 3; j++)
          {
            if (Tabuleiro[j, i] == '-')
            {
              Tabuleiro[j, i] = 'O';
              return;
            }
          }
        }
        quantidadeX = 0;
      }


      /******************************/
      quantidadeX = 0;
      //escolhe posição na linha quando o adversario so colocou uma peça na linha
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (Tabuleiro[i, j] == 'X')
            quantidadeX++;

        }

        if (quantidadeX == 1)
        {
          for (int j = 0; j < 3; j++)
          {
            if (Tabuleiro[i, j] == '-')
            {
              Tabuleiro[i, j] = 'O';
              return;
            }
          }
        }
      }

      quantidadeX = 0;
      //escolhe posição na coluna quando o adversario so colocou uma peça na coluna
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (Tabuleiro[j, i] == 'X')
            quantidadeX++;

        }

        if(quantidadeX == 1)
        {
          for (int j = 0; j < 3; j++)
          {
            if (Tabuleiro[j, i] == '-')
            {
              Tabuleiro[j, i] = 'O';
              return;
            }
          }
        }        
      }
    }

    private static Posicao RandomPosicao()
    {
      int indice = 0;
      Random random = new Random();
      indice = random.Next(0, 8);

      Posicao[] posicao = new Posicao[9];

      posicao[0] = new Posicao(0, 0);
      posicao[1] = new Posicao(0, 1);
      posicao[2] = new Posicao(0, 2);
      posicao[3] = new Posicao(1, 0);
      posicao[4] = new Posicao(1, 1);
      posicao[5] = new Posicao(1, 2);
      posicao[6] = new Posicao(2, 0);
      posicao[7] = new Posicao(2, 1);
      posicao[8] = new Posicao(2, 2);

      return posicao[indice];
    }


  }


}