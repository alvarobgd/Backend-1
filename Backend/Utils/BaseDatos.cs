namespace Backend.Utils
{
    using Backend.modelos;
    using System;
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;
    


    public class BaseDatos
    {
        private string connectionString;
        private string aux;


        public BaseDatos(string host, string database, string user, string password)
            
        {
   
            connectionString = $"Server={host}; Database={database}; Uid={user}; Pwd={password};";
        }

        public List<EmpleadoOficina> GetEmpleadosOficinas()
        {
            List<EmpleadoOficina> empleadosOficinas = new List<EmpleadoOficina>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT EmpleadoID, Nombre, Apellido, OficinaID, OficinaDireccion, Cargo, Salario FROM EmpleadosOficinas";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmpleadoOficina empleadoOficina = new EmpleadoOficina
                            {
                                EmpleadoID = reader.GetInt32("EmpleadoID"),
                                Nombre = reader.GetString("Nombre"),
                                Apellido = reader.GetString("Apellido"),
                                OficinaID = reader.GetInt32("OficinaID"),
                                OficinaDireccion = reader.GetString("OficinaDireccion"),
                                Cargo = reader.GetString("Cargo"),
                                Salario = reader.GetDecimal("Salario")
                            };
                            empleadosOficinas.Add(empleadoOficina);
          
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return empleadosOficinas;
        }

        public List<Oficinas> GetOficinas()
        {
            List<Oficinas> oficinas = new List<Oficinas>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ide, Provincia, Ciudad, direccion, telefono FROM oficinas";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Oficinas oficina = new Oficinas
                            {
                                ide = reader.GetInt32("ide"),
                                Provincia = reader.GetString("Provincia"),
                                Ciudad = reader.GetString("Ciudad"),
                                Direccion = reader.GetString("direccion"),
                                Telefono = reader.GetString("telefono")
                            };
                            oficinas.Add(oficina);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return oficinas;
        }
        public void RegistrarEmpleado(EmpleadoNuevo empleado)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                  

                    conn.Open();
                    string query = "INSERT INTO laarcourier.empleados" +
                        "(Nombre, Apellido, fecha_nacimiento, fecha_contratacion, Oficina, Cargo, Salario)" +
                         "VALUES (@Nombre, @Apellido, @fecha_nacimiento, @fecha_contratacion, @Oficina, @Cargo, @Salario)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", empleado.Fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@fecha_contratacion", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Oficina", empleado.Oficina);
                    cmd.Parameters.AddWithValue("@Cargo", empleado.Cargo);
                    cmd.Parameters.AddWithValue("@Salario", empleado.Salario);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    
}

}
