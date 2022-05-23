using System;

namespace Filas
{
    class Program
    {
        static void Main(string[] args)
        {
            conection NovaConexao = new conection();
            NovaConexao.Conexao();
            NovaConexao.Iniciar();
            NovaConexao.Insert();
            NovaConexao.select();
            NovaConexao.delete();
        }
    }
}
