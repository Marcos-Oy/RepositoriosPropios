//MOSTRAR DATOS
public void MostrarDatos()
{
    try
    {
        con.connect();

        DataSet data = new DataSet();
        data.Clear();
        MySqlDataAdapter adaptador = new MySqlDataAdapter("SELECT id, tipo, rut, nombres, apellido_p, apellido_m, telefono, email, password FROM usuarios", ConnectionMySQL.conector);
        adaptador.Fill(data, "usuarios");
        dataGridView1.DataSource = data;
        dataGridView1.DataMember = "usuarios";
    }
    catch (Exception ex)
    {
        MessageBox.Show("ERROR AL LISTAR DATOS! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    finally
    {
        con.disconnect();
    }

}

//BUSCAR DATOS
private void BuscarDatos()
{
    try
    {
        con.connect();

        DataSet data = new DataSet();
        data.Clear();
        MySqlDataAdapter adaptador = new MySqlDataAdapter("SELECT * FROM usuarios WHERE (id LIKE'" + txtBuscar0.Text + "%' OR tipo LIKE'" + txtBuscar0.Text + "%' OR rut LIKE'" + txtBuscar0.Text + "%' OR nombres LIKE'" + txtBuscar0.Text + "%' OR apellido_p LIKE'" + txtBuscar0.Text + "%' OR apellido_m LIKE'" + txtBuscar0.Text + "%' OR telefono LIKE'" + txtBuscar0.Text + "%' OR email LIKE'" + txtBuscar0.Text + "%' OR password LIKE'" + txtBuscar0.Text + "%') AND (id LIKE'" + txtBuscar1.Text + "%' OR tipo LIKE'" + txtBuscar1.Text + "%' OR rut LIKE'" + txtBuscar1.Text + "%' OR nombres LIKE'" + txtBuscar1.Text + "%' OR apellido_p LIKE'" + txtBuscar1.Text + "%' OR apellido_m LIKE'" + txtBuscar1.Text + "%' OR telefono LIKE'" + txtBuscar1.Text + "%' OR email LIKE'" + txtBuscar1.Text + "%' OR password LIKE'" + txtBuscar1.Text + "%')", ConnectionMySQL.conector);
        adaptador.Fill(data, "usuarios");
        dataGridView1.DataSource = data;
        dataGridView1.DataMember = "usuarios";
    }
    catch (Exception ex)
    {
        MessageBox.Show("ERROR AL BUSCAR DATOS! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    finally
    {
        con.disconnect();
    }
}

//EXTRAER RUT (Extraer un dato a una variable)
private void ExtraerRut()
{
    try
    {
        con.connect();

        MySqlCommand comando = new MySqlCommand("SELECT * FROM usuarios WHERE rut='" + txtRut.Text + "'", con.conexion);
        comando.Parameters.AddWithValue("@rut", txtRut.Text);
        MySqlDataReader registro = comando.ExecuteReader();
        if (registro.Read())
        {
            registro["rut"].ToString(); //recordar crear variables como objetos
            MessageBox.Show("Ups! al parecer este RUT ya se encuentra registrado, por favor intente con otro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            con.disconnect();
        }
        else
        {
            con.disconnect();
            ExtraerTelefono();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("ERROR AL EXTRAER RUT! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        con.disconnect();
    }
}

//INSTERTAR DATOS
public void InsertarDatos()
{
    if (count == 0)
    {
        try
        {
            con.connect();
            MySqlCommand comando = new MySqlCommand("INSERT INTO usuarios(tipo , rut, nombres, apellido_p, apellido_m, telefono, email, password) VALUES ('" + cmbTipo.Text + "','" + txtRut.Text + "','" + txtNombres.Text + "','" + txtApellidoP.Text + "' ,'" + txtApellidoM.Text + "' ,'" + txtTelefono.Text + "','" + txtEmail.Text + "','" + txtPass0.Text + "')", con.conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("INSERCIÓN COMPLETADA!", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("ERROR AL INSERTAR DATOS! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            con.disconnect();
        }
    }
}

//ACTUALIZAR DATOS
public void ActualizarDatos()
{
    if (count == 1)
    {
        try
        {
            con.connect();

            MySqlCommand comando = new MySqlCommand("UPDATE usuarios SET tipo='" + cmbTipo.Text + "', rut='" + txtRut.Text + "', nombres='" + txtNombres.Text + "', apellido_p='" + txtApellidoP.Text + "', apellido_m='" + txtApellidoM.Text + "', telefono='" + txtTelefono.Text + "', email='" + txtEmail.Text + "', password='" + txtPass0.Text + "' WHERE id='" + id + "'", con.conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("EDICIÓN COMPLETADA!", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        catch (Exception ex)
        {
            MessageBox.Show("ERROR AL EDITAR DATOS! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            con.disconnect();
        }
    }
}

//ELIMINAR DATOS
public void EliminarDatos()
{
    if (count == 1)
    {
        try
        {
            con.connect();

            MySqlCommand comando = new MySqlCommand("DELETE FROM usuarios WHERE id='" + id + "'", con.conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("ELIMINACIÓN COMPLETADA!", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        catch (Exception ex)
        {
            MessageBox.Show("ERROR AL ELIMINAR DATOS! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            con.disconnect();
        }
    }
}
