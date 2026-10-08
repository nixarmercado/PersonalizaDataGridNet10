using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();

        //Metodo para mostar los datos de la tabla
        public DataTable MostrarProd()
        {
            //Objeto de tipo DataTable el cual ayuda al momento de obtencio de datos para la Grid
            DataTable tabla = new DataTable();
            //Llama al metodo de CD_Productos para ir a extraer la informacion de la tabla
            tabla = objetoCD.Mostrar();
            //Regresa la informacion encontrada en la base de datos
            return tabla;
        }

        //Metodo que se comunica con la capa de datos para almacenar por medio de consulta la informacion dentro del formulario
        public void InsertarProductos(string nombre, string descrp, string marca, string precio, string stock)
        {
            //Se recibe datos de tipo String y se convierten los que son de tipo Numerico para evitar errores
            objetoCD.Insertar(nombre, descrp, marca, Convert.ToDecimal(precio), Convert.ToInt16(stock));
        }

        //Metodo
        public void EditarProductos(string nombre, string descrp, string marca, string precio, string stock, string id)
        {
            objetoCD.Editar(nombre, descrp, marca, Convert.ToDecimal(precio), Convert.ToInt16(stock), Convert.ToInt32(id));
        }

        public void EliminarProducto(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}
