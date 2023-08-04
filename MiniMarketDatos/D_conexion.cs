using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MiniMarketDatos
{
    public class D_conexion
    {
        private string Base;
        private string Servidor;
        private string Contraseña;
        private string Usuario;
        private bool Seguridad;
        private static D_conexion con = null;


        private D_conexion()
        {
            this.Base = "DB_MiniMarket";
            this.Servidor = "MasterG";
            this.Contraseña = "12345";
            this.Usuario = "masterG";
            this.Seguridad = false;


        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = $"Server={this.Servidor}; Database={this.Base}; ";
                if (Seguridad == true) 
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "Integrated Security == SSPI";
                }
                else
                {
                    Cadena.ConnectionString= Cadena.ConnectionString + $"User Id={this.Usuario}; Password={this.Contraseña}";
                }
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static D_conexion GetInstancia()
        {
            if(con == null)
            {
                con = new D_conexion();
            }
            return con;
        }
    }
}
