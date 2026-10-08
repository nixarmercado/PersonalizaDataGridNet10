using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaDatos
{
    public class CD_Conexion
    {
        //Cadena de conexion
        private SqlConnection conexion = 
            new SqlConnection("Server=DESKTOP-2KMOS3T\\SQLEXPRESS;DataBase=PruebaProductos;" 
                +"Integrated Security=True;TrustServerCertificate=True");


        //Metodos para abrir y cerrar la conexion
        public SqlConnection AbrirConexion()
        {
            if(conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if(conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
    }
}
