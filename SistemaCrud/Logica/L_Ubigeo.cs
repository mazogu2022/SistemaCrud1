using SistemaCrud.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SistemaCrud.Logica
{
    public class L_Ubigeo
    {
        private static L_Ubigeo _instancia;

        private L_Ubigeo() { }

        public static L_Ubigeo Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new L_Ubigeo();
                }
                return _instancia;
            }
        }

        public List<tbubigeo> Listar()
        {
            List<tbubigeo> lista = new List<tbubigeo>();
            using (SQLiteConnection conn = Conexion.Instancia.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT Distrito, Provincia, Departamento FROM tbubigeo";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new tbubigeo
                        {
                            Distrito = dr["Distrito"].ToString(),
                            Provincia = dr["Provincia"].ToString(),
                            Departamento = dr["Departamento"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public List<tbubigeo> Buscar(string criterio)
        {
            List<tbubigeo> lista = new List<tbubigeo>();
            using (SQLiteConnection conn = Conexion.Instancia.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT Distrito, Provincia, Departamento FROM tbubigeo WHERE Distrito LIKE @criterio";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@criterio", $"%{criterio}%");
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new tbubigeo
                            {
                                Distrito = dr["Distrito"].ToString(),
                                Provincia = dr["Provincia"].ToString(),
                                Departamento = dr["Departamento"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
