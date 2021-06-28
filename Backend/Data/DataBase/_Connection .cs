namespace Backend.Data.DataBase
{
    //Renomeie para Connection (Sem underline)
    //Troque os dados de acesso ao seu banco
    public class _Connection
    {
        protected static string Database { get; } = "seubanco";
        protected static string PassWord { get; } = "suaSenha";
        protected static string User { get; } = "sa";
        protected static string Server { get; } = "localhost";
        public string ConnectionString { get; } = $"Password={PassWord} ;Persist Security Info=True;User ID={User};Initial Catalog={Database};Data Source={Server}";
    }
}