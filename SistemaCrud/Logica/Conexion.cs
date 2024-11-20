using System;
using System.Data.SQLite;

namespace SistemaCrud.Logica
{
    public class Conexion
    {
        private static Conexion _instancia; // Instancia única (Singleton)
        private static string connectionString = "Data Source=bdbase.db;Version=3;"; // Ruta de la base de datos SQLite
        private SQLiteConnection _conexion;

        // Constructor privado para evitar la instanciación externa
        private Conexion()
        {
            _conexion = new SQLiteConnection(connectionString);
        }

        // Propiedad para obtener la instancia única
        public static Conexion Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Conexion();
                }
                return _instancia;
            }
        }

        // Método para obtener la conexión SQLite
        public SQLiteConnection ObtenerConexion()
        {
            // Devuelve una nueva instancia de conexión basada en la cadena de conexión
            return new SQLiteConnection(connectionString);
        }
    }
}
