using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Filas
{
    class Paciente
    {
        public string nome;
        public string cpf;
        public string sexo;
        public string alergias;
        public string telefone;
        public string necEsp;
        public string Necessidade;
        public int cod_Necessidade;
        public int cod_paciente;

 
        public void Cadastro()
        {
            Console.Clear();
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
