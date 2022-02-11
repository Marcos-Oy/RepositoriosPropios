using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SisInventario.DataAcces
{
    class ConnectionMySQL
    {
        public static string server = "localhost"; //Dirección del host o servidor
        public static string port = "3306"; //Puerto
        public static string userid = "root"; //Usuario del motor de BD
        public static string password = "admin"; //Contraseña del usuario del motor BD
        public static string database = "mini_market"; //Nombre de la BD

        public static string conector = ("server=" + server + "; port=" + port + "; userid=" + userid + "; password=" + password + "; database=" + database);
        public MySqlConnection conexion = new MySqlConnection(conector);

        public void connect()
        {
            try
            {
                // Se abre la conexion
                conexion.Open();
                // MessageBox.Show("conectado a la BD"); //Descomentar para probar la conexión
            }
            catch (Exception ex)
            {
                // Menseje de error al conectar a la base de datos
                MessageBox.Show("Error al conectar " + ex.Message);
            }
        }

        public void disconnect()
        {
            try
            {
                // Se cierra la conexion
                conexion.Close();
                // MessageBox.Show("desconectado de la BD"); //Descomentar para probar la desconexión
            }
            catch (Exception ex)
            {
                // Menseje de error al desconectar a la base de datos
                MessageBox.Show("Error al desconectar " + ex.Message);
            }
        }
    }
}
