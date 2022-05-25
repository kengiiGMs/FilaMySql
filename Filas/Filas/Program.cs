using System;

namespace Filas
{
    class Program
    {
        static void Main(string[] args)
        {
            int cont = 0;
            Conection c = new Conection();
            c.Conexao();
            c.Iniciar();
            do
            {
                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("Digite 1 - Para inserir Paciente");
                Console.WriteLine("Digite 2 - Para Listar o Paciente");
                Console.WriteLine("Digite 3 - Para deletar o Paciente");
                Console.WriteLine("Digite 4 - Para sair");
                try
                {
                    cont = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                switch (cont)
                {
                    case 1:
                        c.Insert();
                        break;
                    case 2:
                        c.Select();
                        break;
                    case 3:
                        c.Delete();
                        
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Erro tecla invalida");
                        Console.WriteLine("Digite uma tecla para continuar");
                        Console.ReadKey();
                        break;

                }
            } while (cont != 4);
            
            
           
        }
    }
}
