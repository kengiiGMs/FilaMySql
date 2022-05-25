using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace Filas
{
    class Conection:Paciente
    {
        private MySqlConnection Novaconexao;

       
        //Conexao
        public void Conexao()
        {
            Novaconexao = new MySqlConnection("server=localhost;database=fila;uid=root;password=;"); //Atribuido a esse objeto, a conexão com banco, passando seu nome,user,senha e local
        }

        //Iniciar Conexao
        public void Iniciar()
        {
            try
            {
                Novaconexao.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro ao efetuar a conexao com o banco de dados");
                Console.WriteLine("Digite uma tecla para fechar o programa");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        //Inserir 
        public void Insert()
        {
            if (Novaconexao.State == ConnectionState.Open)
            {

            }
            else
            {
                try
                {
                    Novaconexao.Open();
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Erro ao tentar abrir a conexao");
                    Console.WriteLine("Digite uma tecla para continuar");
                    Console.ReadKey();
                }
            }
            Paciente p = new Paciente();
            p.Cadastro();
            string sql = "INSERT INTO paciente values ( default,@nome,@sexo,@cpf,@telefone,@alergia,@necessidade,@cod_necessidade)";
            MySqlCommand execute = new MySqlCommand(sql, Novaconexao);
            execute.Parameters.AddWithValue("@nome", p.nome);
            execute.Parameters.AddWithValue("@sexo", p.sexo );
            execute.Parameters.AddWithValue("@cpf", p.cpf);
            execute.Parameters.AddWithValue("@telefone", p.telefone );
            execute.Parameters.AddWithValue("@alergia", p.alergias );
            execute.Parameters.AddWithValue("@necessidade", p.Necessidade);
            execute.Parameters.AddWithValue("@cod_necessidade", p.cod_Necessidade);
            execute.ExecuteNonQuery();
          
        }

        //Selecionar
        public void Select()
        {
            if (Novaconexao.State == ConnectionState.Open)
            {

            }else{
                try
                {
                    Novaconexao.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Erro ao tentar abrir a conexao");
                    Console.WriteLine("Digite uma tecla para continuar");
                    Console.ReadKey();
                }
            }
            String sql = "SELECT nome,sexo,cpf,telefone,alergia,necessidade FROM paciente order by cod_necessidade desc ";
            MySqlCommand execute = new MySqlCommand(sql, Novaconexao);
            MySqlDataReader tab = execute.ExecuteReader();
                while (tab.Read())
                {
                    Console.WriteLine("\n nome: {0} sexo: {1} cpf: {2} telefone: {3} alergia: {4} necessidade: {5}", tab["nome"], tab["sexo"], tab["cpf"], tab["telefone"], tab["alergia"], tab["necessidade"]);
                }
            Novaconexao.Close();
            Console.WriteLine("\n---Digite uma tecla para continuar---");
            Console.ReadLine();
        }

        //Deletar
        public void Delete()
        {
            if (Novaconexao.State == ConnectionState.Open)
            {

            }else{
                try
                {
                    Novaconexao.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Erro ao tentar abrir a conexao");
                    Console.WriteLine("Digite uma tecla para continuar");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Digite o cod do Paciente");
            cod_paciente = int.Parse(Console.ReadLine());
            String sql = "delete from paciente where codigo_paciente = @cod_paciente";
            MySqlCommand execute = new MySqlCommand(sql, Novaconexao);
            execute.Parameters.AddWithValue("@cod_paciente", cod_paciente);
            if (execute.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Deletado com sucesso");
                Console.WriteLine("\n---Digite uma tecla para continuar---"); 
                Novaconexao.Close();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Erro Nenhum paciente cadastrado neste indice");
                Console.WriteLine("\n---Digite uma tecla para continuar---");
                Console.ReadKey();
            }
        }
    }
}
