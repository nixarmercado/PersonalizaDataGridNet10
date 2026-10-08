using Microsoft.Data.SqlClient;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            //TRANSACT SQL
           // comando.Connection=conexion.AbrirConexion();
           // comando.CommandText = "SELECT * FROM Producto";
           // leer = comando.ExecuteReader();
           // tabla.Load(leer);
           // comando.Connection=conexion.CerrarConexion();
           // return tabla;

            //PROCEDIMIENTO ALMACENADO
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            comando.Connection = conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string nombre,string descrip, string marca, decimal precio, int stock)
        {
            //TRANSACT SQL
            //comando.Connection = conexion.AbrirConexion();
            //comando.CommandText = "INSERT INTO Producto VALUES('" + nombre + "','" + descrip + "','" + marca + "'," + precio + "," + stock + ")";
            //comando.CommandType = CommandType.Text;
            //comando.ExecuteNonQuery();
            //comando.Connection = conexion.CerrarConexion();

            //Procedimiento Almacenado
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProductos";
            comando.CommandType= CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Descripcion", descrip);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@Precio", precio);
            comando.Parameters.AddWithValue("@Stock", stock);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void Editar(string nombre, string descrip, string marca, decimal precio, int stock, int id)
        {
            comando.Connection= conexion.AbrirConexion();
            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre",nombre);
            comando.Parameters.AddWithValue("@Descripcion", descrip);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@Precio", precio);
            comando.Parameters.AddWithValue("@Stock", stock);
            comando.Parameters.AddWithValue("@Id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            comando.Connection= conexion.CerrarConexion();
        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProductos";
            comando.CommandType= CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdPro", id);

            comando.ExecuteNonQuery ();

            comando.Parameters.Clear();

        }
    }
}
