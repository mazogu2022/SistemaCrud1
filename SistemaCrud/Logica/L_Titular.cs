using SistemaCrud.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SistemaCrud.Logica
{
    public class L_Titular
    {
        private static L_Titular _instancia;
        private L_Titular() { }

        public static L_Titular Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new L_Titular();
                return _instancia;
            }
        }

        public List<M_Titular> Listar()
        {
            List<M_Titular> lista = new List<M_Titular>();
            using (SQLiteConnection conn = Conexion.Instancia.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT idempresa, empresa, identificador, domiciliolegal, distrito, provincia, departamento, ruc, telefono, correo, representante, dni, llama1, llama2, llama3, comentarios FROM tbtitular";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new M_Titular
                        {
                            Idempresa = dr["idempresa"].ToString(),
                            Empresa = dr["empresa"].ToString(),
                            Identificador = dr["identificador"].ToString(),
                            Domiciliolegal = dr["domiciliolegal"].ToString(),
                            Distrito = dr["distrito"].ToString(),
                            Provincia = dr["provincia"].ToString(),
                            Departamento = dr["departamento"].ToString(),
                            Ruc = dr["ruc"].ToString(),
                            Telefono = dr["telefono"].ToString(),
                            Correo = dr["correo"].ToString(),
                            Representante = dr["representante"].ToString(),
                            Dni = dr["dni"].ToString(),
                            Llama1 = dr["llama1"].ToString(),
                            Llama2 = dr["llama2"].ToString(),
                            Llama3 = dr["llama3"].ToString(),
                            Comentarios = dr["comentarios"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public bool Guardar(M_Titular obj)
        {
            using (SQLiteConnection conn = Conexion.Instancia.ObtenerConexion())
            {
                conn.Open();
                string query = @"INSERT INTO tbtitular 
                        (empresa, identificador, domiciliolegal, distrito, provincia, departamento, ruc, telefono, correo, representante, dni, llama1, llama2, llama3, comentarios) 
                        VALUES 
                        (@empresa, @identificador, @domiciliolegal, @distrito, @provincia, @departamento, @ruc, @telefono, @correo, @representante, @dni, @llama1, @llama2, @llama3, @comentarios)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                
                    cmd.Parameters.AddWithValue("@empresa", obj.Empresa);
                    cmd.Parameters.AddWithValue("@identificador", obj.Identificador);
                    cmd.Parameters.AddWithValue("@domiciliolegal", obj.Domiciliolegal);
                    cmd.Parameters.AddWithValue("@distrito", obj.Distrito);
                    cmd.Parameters.AddWithValue("@provincia", obj.Provincia);
                    cmd.Parameters.AddWithValue("@departamento", obj.Departamento);
                    cmd.Parameters.AddWithValue("@ruc", obj.Ruc);
                    cmd.Parameters.AddWithValue("@telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@correo", obj.Correo);
                    cmd.Parameters.AddWithValue("@representante", obj.Representante);
                    cmd.Parameters.AddWithValue("@dni", obj.Dni);
                    cmd.Parameters.AddWithValue("@llama1", obj.Llama1);
                    cmd.Parameters.AddWithValue("@llama2", obj.Llama2);
                    cmd.Parameters.AddWithValue("@llama3", obj.Llama3);
                    cmd.Parameters.AddWithValue("@comentarios", obj.Comentarios);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Modificar(M_Titular obj)
        {
            using (SQLiteConnection conn = Conexion.Instancia.ObtenerConexion())
            {
                conn.Open();
                string query = "UPDATE tbtitular SET empresa = @empresa, identificador = @identificador, domiciliolegal = @domiciliolegal, distrito = @distrito, provincia = @provincia, departamento = @departamento, ruc = @ruc, telefono = @telefono, correo = @correo, representante = @representante, dni = @dni, llama1 = @llama1, llama2 = @llama2, llama3 = @llama3, comentarios = @comentarios WHERE idempresa = @idempresa";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idempresa", obj.Idempresa);
                    cmd.Parameters.AddWithValue("@empresa", obj.Empresa);
                    cmd.Parameters.AddWithValue("@identificador", obj.Identificador);
                    cmd.Parameters.AddWithValue("@domiciliolegal", obj.Domiciliolegal);
                    cmd.Parameters.AddWithValue("@distrito", obj.Distrito);
                    cmd.Parameters.AddWithValue("@provincia", obj.Provincia);
                    cmd.Parameters.AddWithValue("@departamento", obj.Departamento);
                    cmd.Parameters.AddWithValue("@ruc", obj.Ruc);
                    cmd.Parameters.AddWithValue("@telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@correo", obj.Correo);
                    cmd.Parameters.AddWithValue("@representante", obj.Representante);
                    cmd.Parameters.AddWithValue("@dni", obj.Dni);
                    cmd.Parameters.AddWithValue("@llama1", obj.Llama1);
                    cmd.Parameters.AddWithValue("@llama2", obj.Llama2);
                    cmd.Parameters.AddWithValue("@llama3", obj.Llama3);
                    cmd.Parameters.AddWithValue("@comentarios", obj.Comentarios);
                    cmd.Parameters.AddWithValue("@idempresa", obj.Idempresa);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Eliminar(string idempresa)
        {
            using (SQLiteConnection conn = Conexion.Instancia.ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM tbtitular WHERE idempresa = @idempresa";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idempresa", idempresa);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public M_Titular ListarPorId(string idempresa)
        {
            M_Titular obj = null;
            using (SQLiteConnection conn = Conexion.Instancia.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT idempresa, empresa, identificador, domiciliolegal, distrito, provincia, departamento, ruc, telefono, correo, representante, dni, llama1, llama2, llama3, comentarios FROM tbtitular WHERE idempresa = @idempresa";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idempresa", idempresa);
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj = new M_Titular
                            {
                                Idempresa = dr["idempresa"].ToString(),
                                Empresa = dr["empresa"].ToString(),
                                Identificador = dr["identificador"].ToString(),
                                Domiciliolegal = dr["domiciliolegal"].ToString(),
                                Distrito = dr["distrito"].ToString(),
                                Provincia = dr["provincia"].ToString(),
                                Departamento = dr["departamento"].ToString(),
                                Ruc = dr["ruc"].ToString(),
                                Telefono = dr["telefono"].ToString(),
                                Correo = dr["correo"].ToString(),
                                Representante = dr["representante"].ToString(),
                                Dni = dr["dni"].ToString(),
                                Llama1 = dr["llama1"].ToString(),
                                Llama2 = dr["llama2"].ToString(),
                                Llama3 = dr["llama3"].ToString(),
                                Comentarios = dr["comentarios"].ToString()
                            };
                        }
                    }
                }
            }
            return obj;
        }

        internal bool Eliminar(int idempresa)
        {
            throw new NotImplementedException();
        }
    }
}
