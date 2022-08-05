using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo01
{
    public partial class Frm_empleados : Form
    {
        int personal;
        int comicion;
        //int movilidadPER = 250;
        //int movilidadCOM = 110;
        int cVentas, cMarketing, cLogistica, cPrestamos,num;


        public Frm_empleados()
        {
            InitializeComponent();

            txtNombre.Focus();

        }

        private void Listado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Estadistica(string v1)
        {

            //Contabilizar la cantidad segun los cargos
            switch (v1)
            {
                case "Ventas": cVentas++; break;
                case "Marketing": cMarketing++; break;
                case "Logistica": cLogistica++; break;
                case "Prestamos": cPrestamos++; break;
            }

            estadisticas.Items.Clear();
            string[] elementosFila = new string[2];
            ListViewItem row;

            elementosFila[0] = " total de personal del area de Ventas";
            elementosFila[1] = cVentas.ToString();
            row = new ListViewItem(elementosFila);
            estadisticas.Items.Add(row);


            elementosFila[0] = " total de personal del area de Marketing";
            elementosFila[1] = cMarketing.ToString();
            row = new ListViewItem(elementosFila);
            estadisticas.Items.Add(row);


            elementosFila[0] = "Total de personal del area de Logistica";
            elementosFila[1] = cLogistica.ToString();
            row = new ListViewItem(elementosFila);
            estadisticas.Items.Add(row);


            elementosFila[0] = " Total de peronal del area de Prestamos";
            elementosFila[1] = cPrestamos.ToString();
            row = new ListViewItem(elementosFila);
            estadisticas.Items.Add(row);
            //ancho de columna aoutomatico
            estadisticas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            estadisticas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


        }
        private bool validar(string v1, string v2)
        {
            //validar
            if (v1.Length == 0 || v2.Length == 0)
            {
                MessageBox.Show("Faltan Datos");
                return false;
            }
            else
                return true;
        }
            private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           
            this.Close();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Frm_empleados_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //capturando datos 
            string empleado = txtNombre.Text;
            int numero_hijos = Convert.ToInt32( numHijos.Text);
            string area = cboArea.Text;
            string condicion = cboCondicion.Text;
            
            //capturando tiempo  de servicio
            DateTime fechaInit = Convert.ToDateTime( dateTimePicker1.Text);
            string tiempoServ = Convert.ToString((DateTime.Now.Year) - (fechaInit.Year));




            //asignado  el sueldo a la condicion
            if (condicion == "personal")  personal = 2500;
            if (condicion == "comision")  comicion = 1100;

            //estatico que se presentara en  la colunma sueldo base
            double estaticSueldoPer = 2500;
            double estaticSueldoCom = 1100;

            double estaticSueldo = 0;
            if (condicion == "personal") estaticSueldo = estaticSueldoPer;
            if (condicion == "comision") estaticSueldo = estaticSueldoCom;


            //  costo de movilidad estatico 
            double movilidadPER = 2500*0.10;
           double movilidadCOM = 1100*0.10;
            double estaticMovilidad = 0;
            if (condicion == "personal") estaticMovilidad = movilidadPER;
            if (condicion == "comision") estaticMovilidad = movilidadCOM;


            //asignacion por  cantidad de hijos
            int Xhijo = 20;
            int asignacion = Xhijo*numero_hijos;



            // suma entre tipo de sueldo  y tipo de movilidad
            double movilidad = 0;

            if (condicion == "personal ") movilidad = personal+ movilidadPER;
            if (condicion == "comision") movilidad = comicion + movilidadCOM;



            double descuentoPER = 2500*0.17;
            double descuentoCOM = 1100*0.17;

            //lo que se mostrra en la colunma descuento en listview
            double estaticDescuento = 0;
            if (condicion == "personal") estaticDescuento = descuentoPER;
            if (condicion == "comision") estaticDescuento = descuentoCOM;

            //descontando 17% segun tipo de sueldo
            Double descuento = 0;
            if (condicion == "personal") descuento = personal - descuentoPER;
            if (condicion == "comision") descuento = comicion - descuentoCOM;

            //operacion para sacar el sueldo neto 
            double neto = 0;
            if (condicion == "personal") neto = estaticSueldo + estaticMovilidad + asignacion - estaticDescuento;
            if (condicion == "comision") neto = estaticSueldo + estaticMovilidad + asignacion - estaticDescuento;

            //llenando datos en lisview
            ListViewItem fila = new ListViewItem(empleado);
            fila.SubItems.Add(numero_hijos.ToString("0"));
            fila.SubItems.Add(area);
            fila.SubItems.Add(condicion);
            fila.SubItems.Add(tiempoServ);
            fila.SubItems.Add(estaticSueldo.ToString("0.0"));
            fila.SubItems.Add(estaticMovilidad.ToString("0.0"));
            fila.SubItems.Add(asignacion.ToString("0"));
            fila.SubItems.Add(estaticDescuento.ToString("0"));
            fila.SubItems.Add(neto.ToString("0.0"));
            listView1.Items.Add(fila);
            //ancho de columna automatico
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            // validacion y llamado de metodo para el conteo de personal
            if (validar(empleado, area))
            {
               
                Estadistica(area);
                num++;
                lblNumero.Text = num.ToString();
            }

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
