namespace Aplicacion.CadenaConexion
{
    public static class CadenaConecion
    {
        // Atributos
        private const string Servidor = @"NCPI000000066\SQLEXPRESS01"; // Cambia
        private const string BaseDatos = @"comercio";
        private const string Usuario = @"sa";
        private const string Password = @"123456"; // Cambia

        // Propiedad
        public static string ObtenerCadenaSql => $"Data Source={Servidor}; " +
                                                 $"Initial Catalog={BaseDatos}; " +
                                                 $"User Id={Usuario}; " +
                                                 $"Password={Password};";

        public static string ObtenerCadenaWin => $"Data Source={Servidor}; " +
                                                 $"Initial Catalog={BaseDatos}; " +
                                                 $"Integrated Security=true;";
    }
}
