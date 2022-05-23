using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace Filas
{
    class conection
    {
        private MySqlConnection Novaconexao;
        protected string nome;
        protected string cpf;
        protected string sexo;
        protected string alergias;
        protected string telefone;
        protected string necEsp;
        protected string Necessidade;
        protected int cod_Necessidade;
        protected int cod_paciente;

        public void Conexao()
        {
            Novaconexao = new MySqlConnection("server=localhost;database=fila;uid=root;password=;"); //Atribuido a esse objeto, a conexão com banco, passando seu nome,user,senha e local
        }
        public void Iniciar()
        {
            try
            {
                Novaconexao.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro na conexao");
                Environment.Exit(0);
            }
        }
        public void Fechar()
        {
            try
            {
                Novaconexao.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro em fechar a conexao");
                Environment.Exit(0);
            }
        }
        public void Insert()
        {
            Console.Clear();
            Console.WriteLine("Digite o cod do Paciente");
            cod_paciente = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do Paciente");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o sexo do Paciente");
            sexo = Console.ReadLine();
            Console.WriteLine("Digite o cpf do Paciente");
            cpf = Console.ReadLine();
            Console.WriteLine("Digite o Telefone do Paciente");
            telefone = Console.ReadLine();
            CadastroAlergia();
            CadastroNecessidade();
            Console.WriteLine();
            if (Novaconexao.State == ConnectionState.Open)
            {

            }
            else
            {
                Novaconexao.Open();
            }

            string sql = "INSERT INTO paciente values (@codigo_paciente,@nome,@sexo,@cpf,@telefone,@alergia,@necessidade,@cod_necessidade)";
            MySqlCommand execute = new MySqlCommand(sql, Novaconexao);


            execute.Parameters.AddWithValue("@codigo_paciente", this.cod_paciente);
            execute.Parameters.AddWithValue("@nome", this.nome);
            execute.Parameters.AddWithValue("@sexo", this.sexo);
            execute.Parameters.AddWithValue("@cpf", this.cpf);
            execute.Parameters.AddWithValue("@telefone", this.telefone);
            execute.Parameters.AddWithValue("@alergia", this.alergias);
            execute.Parameters.AddWithValue("@necessidade", this.Necessidade);
            execute.Parameters.AddWithValue("@cod_necessidade", this.cod_Necessidade);
            if (execute.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Cadastro com sucesso");
                Novaconexao.Close();
                Console.ReadKey();

            }


        }
        public void select()
        {
            if (Novaconexao.State == ConnectionState.Open)
            {

            }
            else
            {
                Novaconexao.Open();
            }
            String sql = "SELECT * FROM paciente";
            MySqlCommand execute = new MySqlCommand(sql, Novaconexao);
            MySqlDataReader tab = execute.ExecuteReader();
            while (tab.Read())
            {
                Console.WriteLine("Id:{0} nome:{1} sexo{2} cpf{3} telefone{4} alergia{5} necessidad{6}", tab["codigo_paciente"], tab["nome"], tab["sexo"], tab["cpf"], tab["telefone"], tab["alergia"], tab["necessidade"]);
            }
            Novaconexao.Close();
            Console.ReadLine();

        }

        public void delete()
        {

            if (Novaconexao.State == ConnectionState.Open)
            {

            }
            else
            {
                Novaconexao.Open();
            }
            Console.WriteLine("Digite o cod do Paciente");
            cod_paciente = int.Parse(Console.ReadLine());
            String sql = "delete from paciente where codigo_paciente = @cod_paciente";
            MySqlCommand execute = new MySqlCommand(sql, Novaconexao);
            execute.Parameters.AddWithValue("@cod_paciente", this.cod_paciente);
            //execute.ExecuteNonQuery();
            if (execute.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Cadastro com sucesso");
                Novaconexao.Close();
                Console.ReadKey();

            }

        }
        public void CadastroAlergia()
        {
            Console.WriteLine("O paciente possui algum tipo de alergia? (S/N)");
            alergias = Console.ReadLine();
            if (alergias.ToUpper() == "S")
            {
                alergias = "Possui alergias";
            }
            else if (alergias.ToUpper() == "N")
            {
                alergias = "Não possui alergias";
            }
        }

        public void CadastroNecessidade()
        {
            Console.WriteLine("O Paciente possui algum tipo de Necessidade Especial? (S/N)");
            necEsp = Console.ReadLine();
            if (necEsp.ToUpper() == "S")
            {

                Necessidade = "Possui Necessidade";
                cod_Necessidade = 20;

            }
            else if (necEsp.ToUpper() == "N")
            {
                Necessidade = "Não possui Necessidade";
                cod_Necessidade = 10;
            }
        }


    }
}
