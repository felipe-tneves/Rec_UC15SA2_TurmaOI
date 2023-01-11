namespace Rec_UC15SA2_TurmaOI.Classes
{
    public class PessoaJuridica : Pessoa
    {
        public string? CNPJ { get; set; }

        //XX.XXX.XXX/0001-XX
        public bool ValidarCnpj(string CNPJ)
        {
            if (CNPJ.Length == 18)
            {
                if(CNPJ.Substring(11, 4) == "0001")
                {
                    return true;
                }
            }

            return false;
        }

        public void Inserir(PessoaJuridica pj)
        {
            using(StreamWriter sw = new StreamWriter($"{pj.Nome}.txt"))
            {
                sw.WriteLine($"{pj.Nome},{pj.Rendimento},{pj.CNPJ}");
            }
        }

        //[Felipe,1000,123456789] => [0,1,2] => 3 Posições 
        public PessoaJuridica Ler(string nomeArquivo)
        {
            PessoaJuridica pj = new PessoaJuridica();

            using(StreamReader sr = new StreamReader($"{nomeArquivo}.txt"))
            {
                string[] atributos = sr.ReadLine()!.Split(",");

                pj.Nome = atributos[0];
                pj.Rendimento = float.Parse(atributos[1]);
                pj.CNPJ = atributos[2];
            }

            return pj;
        }
    }
}