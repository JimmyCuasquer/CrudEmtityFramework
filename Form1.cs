﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudFinal.Models;
namespace CrudFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refrescar();
        }
        private void refrescar()
        {
            using (CrudEntities db = new CrudEntities())
            {
                var lst = from d in db.cliente
                          select d;
                dataGridView1.DataSource = lst.ToList();
            }
        }
        private int? GetId()
        {
            try
            {
            return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch {
                return null; 
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Presentaciones.FrmTabla ofrmTabla = new Presentaciones.FrmTabla();
            ofrmTabla.ShowDialog();

            refrescar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if(id != null)
            {
                Presentaciones.FrmTabla otabla = new Presentaciones.FrmTabla(id);
                otabla.ShowDialog();

                refrescar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                using (CrudEntities db = new CrudEntities())
                {
                    cliente ocliente = db.cliente.Find(id);
                    db.cliente.Remove(ocliente);
                    db.SaveChanges();
                }
                
                refrescar();
            }
        }
    }
}
