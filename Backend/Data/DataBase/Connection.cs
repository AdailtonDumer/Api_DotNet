namespace Backend.Data.DataBase
{
    public class Connection
    {
        protected static string Database { get; } = "dbProducts";
        protected static string PassWord { get; } = "Adailtonlucas12";
        protected static string User { get; } = "sa";
        protected static string Server { get; } = "localhost";
        public string ConnectionString { get; } = $"Password={PassWord} ;Persist Security Info=True;User ID={User};Initial Catalog={Database};Data Source={Server}";
    }
}