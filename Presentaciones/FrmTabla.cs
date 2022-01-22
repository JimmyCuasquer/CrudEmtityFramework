using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudFinal.Models;
namespace CrudFinal.Presentaciones
{
    public partial class FrmTabla : Form
    {
        public int? id;
        cliente ocliente = null;
        public FrmTabla(int? id=null)
        {
            InitializeComponent();
            this.id = id;
            if (id != null)
            {
                CargarDatos();
            }
        }
        private void CargarDatos()
        {
            using (CrudEntities db = new CrudEntities())
            {
                ocliente  = db.cliente.Find(id);
                txtCorreo.Text = ocliente.correo;
                txtNombre.Text = ocliente.nombre;
                dtFechaDeNacimiento.Value = ocliente.fecha_de_nacimiento;
        
                    
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (CrudEntities db = new CrudEntities())
            {
                if(id == null)
                    ocliente = new cliente();

                    ocliente.nombre = txtNombre.Text;
                    ocliente.correo = txtCorreo.Text;
                    ocliente.fecha_de_nacimiento = dtFechaDeNacimiento.Value;

                    if(id == null)
                        db.cliente.Add(ocliente);
                    else
                    {
                        db.Entry(ocliente).State = System.Data.Entity.EntityState.Modified; 
                    }
                    db.SaveChanges();

                    this.Close();

            }
        }
    }
}
